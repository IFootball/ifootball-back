﻿using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAuthenticateAsync(string email, string password);
        Task CreateUserAsync(User user);
        Task<bool> UserExistsById(long id);
        Task<User> FindUserById(long id);
        Task<bool> UserExistsByEmail(string email);
        Task DeleteUserAsync(User user);
        Task EditUserAsync(User user);
    }
}
