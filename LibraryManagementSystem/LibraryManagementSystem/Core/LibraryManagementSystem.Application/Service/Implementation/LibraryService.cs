using AutoMapper;
using Cachelibrary.Interface;
using LibraryManagementSystem.Application.Common.Cache;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.Service.Interface;
using LibraryManagementSystem.Domain.Entities.Dtos;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using LibraryManagementSystem.Domain.Interfaces.IWrapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Service.Implementation
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMessageProvider _messageProvider;
        private readonly IMapper _mapper;
        private readonly ILogger<LibraryService> _Logger;
        private readonly IConfiguration config;

        public LibraryService(ILibraryRepository libraryRepository, IMessageProvider _messageProvider, IMapper _mapper, ILogger<LibraryService> _Logger, IConfiguration config)
        {
            _libraryRepository = libraryRepository;
            this._messageProvider = _messageProvider;
            this._mapper = _mapper;
            this._Logger = _Logger;     
            this.config= config;

        }


        public async Task<PayloadResponse<object>> AddBook(BookDto book)
        {
           await _libraryRepository.InsertBookAsyn(book);
            return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL), null, true);
        }

        public async Task<PayloadResponse<object>> DeleteBook(int Id)
        {
          var rst= await _libraryRepository.GetBooksByID(Id);
            if (rst == null) return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.DATA_NOT_EXIST, _messageProvider.GetMessage(ResponseCodes.DATA_NOT_EXIST), null, false);
            await _libraryRepository.DeleteBook(Id);
            return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL), null, true);
        }

        public async Task<PayloadResponse<object>> GetBooks()
        {
           var rst= await _libraryRepository.GetBooksAsync();
            return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL), rst, true);
        }

        public async Task<PayloadResponse<object>> GetToken(LoginDto login)
        {
            if (login.Username == "testuser" && login.Password == "password")
            {
                var token = TokenGenerator.GenerateJwtToken(login.Username, config);
                return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL),new {Token= token } , true);
               
            }
            
            return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.UNUTHORIZED, _messageProvider.GetMessage(ResponseCodes.UNUTHORIZED), null, true);
           
        }

        public async Task<PayloadResponse<object>> UpdateBook(BookDto book)
        {
            var rst = await _libraryRepository.GetBooksByID(book.Id);
            if (rst == null) return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.DATA_NOT_EXIST, _messageProvider.GetMessage(ResponseCodes.DATA_NOT_EXIST), null, false);
            await _libraryRepository.UpdateBook(book);
            return ResponseStatus<object>.Create<PayloadResponse<object>>(ResponseCodes.SUCCESSFUL, _messageProvider.GetMessage(ResponseCodes.SUCCESSFUL), null, true);
        }
    }
}
