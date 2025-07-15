using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using LibraryManagementSystem.Domain.Interfaces.IWrapper;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories;

namespace LibraryManagementSystem.Infrastructure.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SSODbContext _context;
        private IUserRepository _userRepository;
        public RepositoryWrapper(SSODbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }

        }
    }
}
