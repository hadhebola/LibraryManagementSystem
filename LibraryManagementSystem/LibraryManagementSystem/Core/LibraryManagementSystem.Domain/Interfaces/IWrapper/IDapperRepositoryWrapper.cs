using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Interfaces.IRepository;

namespace LibraryManagementSystem.Domain.Interfaces.IWrapper
{
    public interface IDapperRepositoryWrapper
    {
        IUserDapperRepository UserDapperRepository { get; }
    }
}
