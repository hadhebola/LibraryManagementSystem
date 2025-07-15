using LibraryManagementSystem.Application.Common.Responses;
using LibraryManagementSystem.Domain.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.QueryCommand
{
    public class RetrieveAllBooksCommand : IRequest<PayloadResponse<object>>
    {
    }
}
