using LibraryManagementSystem.Domain.Interfaces.IFactory;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using LibraryManagementSystem.Domain.Interfaces.IWrapper;
using LibraryManagementSystem.Infrastructure.Repository;


namespace LibraryManagementSystem.Infrastructure.Wrapper
{
    public class DapperRepositoryWrapper : IDapperRepositoryWrapper
    {
        private IDbConnectionFactory _connectionFactory;
        private IUserDapperRepository _userRepository;

        public DapperRepositoryWrapper(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IUserDapperRepository UserDapperRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserDapperRepository(_connectionFactory);
                }
                return _userRepository;
            }
        }
    }
}
