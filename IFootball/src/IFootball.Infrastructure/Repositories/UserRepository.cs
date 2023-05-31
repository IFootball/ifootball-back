using IFootball.Domain.Contracts.Repositories;
using IFootball.Infrastructure.Data;

namespace IFootball.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
    }
}
