using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Dals;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using LibraryManagementSystem.Infrastructure.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(SSODbContext context)
            : base(context)
        {

        }
    }
}
