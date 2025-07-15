using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Domain.Entities.Dtos;
using MediatR;

namespace LibraryManagementSystem.Application.Commands
{
    public class CreateUserCommand : IRequest<PayloadResponse<UsersDto>>
    {
        public string UserName { get; set; }
        public string PhoneNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
