using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.QueryCommand;
using LibraryManagementSystem.Application.Service.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Handler
{
    public class RetrieveAllBooksCommandHandler : IRequestHandler<RetrieveAllBooksCommand, PayloadResponse<object>>
    {
        private readonly ILibraryService _libraryService;

        public RetrieveAllBooksCommandHandler(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task<PayloadResponse<object>> Handle(RetrieveAllBooksCommand request, CancellationToken cancellationToken)
        {
            return await _libraryService.GetBooks().ConfigureAwait(false);
        }
    }
}
