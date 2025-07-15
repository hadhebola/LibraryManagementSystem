using FluentValidation;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Domain.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class AddNewBookCommand : BookDto, IRequest<PayloadResponse<object>>
    {
    }

    public class AddNewBookCommandValidator : AbstractValidator<AddNewBookCommand>
    {
        public AddNewBookCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.ISBN).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Author).NotEmpty().MinimumLength(2);
            RuleFor(c => c.PublishedDate).NotEmpty(); 
        }
    }
}
