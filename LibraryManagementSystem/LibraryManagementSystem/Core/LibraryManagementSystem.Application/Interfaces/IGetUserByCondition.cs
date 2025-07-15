using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Dals;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IGetUserByCondition
    {
        Task<Users> GetUserByCondAsync(string condition);
    }
}
