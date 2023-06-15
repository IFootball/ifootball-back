using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public UserRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<User?> GetUserAuthenticateAsync(string email, string password)
        {
            using var conn = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));

            var query = @"";

            return new User{ Email = email, Password = password };
        }
    }
}
