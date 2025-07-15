using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.Service;
using LibraryManagementSystem.Application.Service.Interface;
using LibraryManagementSystem.Domain.Entities.Dtos;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Handler
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, PayloadResponse<object>>
    {
        private readonly ILibraryService _libraryService;
        private readonly IConfiguration _configuration;

        public GetTokenCommandHandler(ILibraryService libraryService, IConfiguration configuration)
        {
            _configuration= configuration;
            _libraryService = libraryService;
        }

        public async Task<PayloadResponse<object>> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {        

            return await _libraryService.GetToken(request).ConfigureAwait(false);
        }
    }
}
