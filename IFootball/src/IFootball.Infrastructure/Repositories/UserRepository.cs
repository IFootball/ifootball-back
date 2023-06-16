using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context, IConfiguration config) : base(config)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserAuthenticateAsync(string email, string password)
        {
            var connection = GetConnection();

            var query = @"";

            if (string.IsNullOrEmpty(email))
                return null;

            return new User { Email = email, Password = password };
        }

    }
}
