using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Dtos;
using MediatR;

namespace LibraryManagementSystem.Application.Queries
{
    public class GetUserQuery : IRequest<UsersDto>
    {
        public string UserId { get; set; }
    }
}
