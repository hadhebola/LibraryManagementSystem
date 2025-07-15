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
    public class DeleteBookCommand: DeleteDto, IRequest<PayloadResponse<object>>
    {

    }

    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);           
        }
        
    }
}
