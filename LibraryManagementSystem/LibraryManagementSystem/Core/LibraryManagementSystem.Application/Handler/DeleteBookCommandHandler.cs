using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Application.Service.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Handler
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, PayloadResponse<object>>
    {
        private readonly ILibraryService _libraryService;

        public DeleteBookCommandHandler(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task<PayloadResponse<object>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _libraryService.DeleteBook(request.Id).ConfigureAwait(false);
        }
    }
}
