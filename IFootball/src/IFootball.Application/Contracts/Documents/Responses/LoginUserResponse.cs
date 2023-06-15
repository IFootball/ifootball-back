using IFootball.Application.Contracts.Documents.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class LoginUserResponse : BaseResponse
    {

        public LoginUserDto? User { get; set; }
        public string? Token { get; set; }

        public LoginUserResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message) { }
        public LoginUserResponse(HttpStatusCode statusCode, LoginUserDto? user, string? message = null) : base(statusCode, message)
        {
            User = user;
        }
    }
}
