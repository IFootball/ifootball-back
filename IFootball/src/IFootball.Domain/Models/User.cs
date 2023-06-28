﻿using IFootball.Domain.Models.enums;
using IFootball.Core;
namespace IFootball.Domain.Models
{
    public class User : BaseEntity
    {
        public long IdClass { get; set; }
        public Class Class { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserRole Role = UserRole.User;

        public List<TeamUser> UserTeamsUser { get; set; }
        
        public User() { }
        public User(string name, string email, string password, long idClass) 
        {
            Name = name;
            Email = email;
            Password = PasswordHasher.HashPassword(password);
            IdClass = idClass;
        }
    }
}
