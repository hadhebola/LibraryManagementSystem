using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClipsHashAndSalt;
using KafkaLibrary.KafkaProducer;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.Factories.Abstracts;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities.Dals;
using LibraryManagementSystem.Domain.Entities.Dtos;
using LibraryManagementSystem.Domain.Interfaces.IWrapper;

namespace LibraryManagementSystem.Application.Factories.Implementations
{
    public class NigeriaUserStrategyFactory : UserStrategyService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMessageProvider _messageProvider;
        private readonly IMapper _mapper;
        private readonly IMessageProducers _messageProducers;
        private IGetUserByCondition _getUserByCondition;

        public NigeriaUserStrategyFactory(IRepositoryWrapper repositoryWrapper, IMessageProvider messageProvider, IMapper mapper, IMessageProducers messageProducers, IGetUserByCondition getUserByCondition)
        {
            _repositoryWrapper = repositoryWrapper;
            _messageProvider = messageProvider;
            _mapper = mapper;
            _getUserByCondition = getUserByCondition;
            _messageProducers = messageProducers;
        }
        public override async Task<PayloadResponse<UsersDto>> UserOnboarding(CreateUserCommand request)
        {
            var hashMethod = HashingAndSalting.GetHashingAndSalting;
            var newUser = new UsersDto();

            // using ClipsHashAndSalt to generate password hash and salt
            var hashResult = hashMethod.GenerateSaltedHash(request.Password);

            var existingUserEmail = await _getUserByCondition.GetUserByCondAsync(request.Email);
            var existingUserPhoneNo = await _getUserByCondition.GetUserByCondAsync(request.PhoneNo);

            if (existingUserEmail != null || existingUserPhoneNo != null)
            {
                return ResponseStatus<UsersDto>.Create<PayloadResponse<UsersDto>>(ResponseCodes.USER_EXIST, _messageProvider.GetMessage(ResponseCodes.USER_EXIST), newUser);
            }

            var user = new Users()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNo = request.PhoneNo,
                UserName = request.UserName,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt,
                CreatedAt = DateTime.UtcNow,
            };

            await _repositoryWrapper.UserRepository.CreateAsync(user);
            await _repositoryWrapper.UserRepository.SaveAsync();

            newUser = _mapper.Map<UsersDto>(user);
            await _messageProducers.ProduceAsync<UsersDto>("User", newUser).ConfigureAwait(false);
            return ResponseStatus<UsersDto>.Create<PayloadResponse<UsersDto>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL), newUser);
        }
    }
}
