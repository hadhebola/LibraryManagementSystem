using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Dals;

namespace LibraryManagementSystem.Domain.Interfaces.IRepository
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
    }
}
