﻿namespace IFootball.Domain.Models
{
    public class User
    {
        public User() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
