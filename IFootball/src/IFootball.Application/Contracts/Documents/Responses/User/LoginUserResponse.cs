using IFootball.Application.Contracts.Documents.Dtos;
using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class LoginUserResponse : BaseResponse
    {

        public LoginUserDto? User { get; set; }
        public string? Token { get; set; }
        
        public LoginUserResponse(LoginUserDto user)
        {
            User = user;
        }
        public LoginUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
