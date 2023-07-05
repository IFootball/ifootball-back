using IFootball.Core;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly DataContext _context;

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
            
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

            if (user is not null && PasswordHasher.VerifyPassword(password, user.Password)) return user;

            return null;
        }

        public async Task<bool> UserExistsById(long id) => await _context.Users.FindAsync(id) is not null;
        public async Task<bool> UserExistsByEmail(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower())) is not null;

        public async Task<User?> FindUserById(long id)
        {
           return await _context.Users.FindAsync(id);
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

    } 
}   
