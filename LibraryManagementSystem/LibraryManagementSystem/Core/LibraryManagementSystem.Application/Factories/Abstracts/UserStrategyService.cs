using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Domain.Entities.Dtos;

namespace LibraryManagementSystem.Application.Factories.Abstracts
{
    public abstract class UserStrategyService
    {
        public abstract Task<PayloadResponse<UsersDto>> UserOnboarding(CreateUserCommand request);
    }
}
