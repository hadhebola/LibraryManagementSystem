using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClipsHashAndSalt;
using KafkaLibrary;
using KafkaLibrary.KafkaProducer;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.Factories.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities.Dals;
using LibraryManagementSystem.Domain.Entities.Dtos;
using LibraryManagementSystem.Domain.Interfaces.IWrapper;
using MediatR;


namespace LibraryManagementSystem.Application.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, PayloadResponse<UsersDto>>
    {

        private readonly IUserStrategyFactory _userStrategyFactory;
        private readonly ICountryService _countryService;

        public CreateUserCommandHandler(IUserStrategyFactory userStrategyFactory, ICountryService countryService)
        {
            _userStrategyFactory = userStrategyFactory;
            _countryService = countryService;
        }
        public async Task<PayloadResponse<UsersDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var countryCode = _countryService.GetCountryCode();
            var userStrategyService = _userStrategyFactory.UserBaseOnStrategy(countryCode);
            return await userStrategyService.UserOnboarding(request).ConfigureAwait(false);
        }
    }
}
