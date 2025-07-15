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
    public class UpdateBookCommand : BookDto, IRequest<PayloadResponse<object>>
    {

    }

    public class UpdateBookCommanddValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommanddValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.ISBN).NotEmpty();
            RuleFor(c => c.Author).NotEmpty();
        }
    }
}
