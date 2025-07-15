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
    public class GetTokenCommand : LoginDto, IRequest<PayloadResponse<object>>
    {
    }

    public class GetTokenCommandValidator : AbstractValidator<GetTokenCommand>
    {
        public GetTokenCommandValidator()
        {

            RuleFor(c => c.Username).NotEmpty().MinimumLength(5);
            RuleFor(c => c.Password).NotEmpty().MinimumLength(8).WithMessage("Password is required.");
               //.MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
               //.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
               //.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
               //.Matches("[0-9]").WithMessage("Password must contain at least one number.")
               //.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character."); 
        }

    }
}
