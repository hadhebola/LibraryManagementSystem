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
    public class AddNewBookCommandHandler : IRequestHandler<AddNewBookCommand, PayloadResponse<object>>
    {
        private readonly ILibraryService _libraryService;

        public AddNewBookCommandHandler(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task<PayloadResponse<object>> Handle(AddNewBookCommand request, CancellationToken cancellationToken)
        {
            return await _libraryService.AddBook(request).ConfigureAwait(false);
        }
    }
}
