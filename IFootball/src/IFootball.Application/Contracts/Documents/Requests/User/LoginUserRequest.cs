﻿namespace IFootball.Application.Contracts.Documents.Requests
{
    public class LoginUserRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
