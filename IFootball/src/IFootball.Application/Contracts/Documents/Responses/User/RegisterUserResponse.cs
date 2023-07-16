using IFootball.Application.Contracts.Documents.Dtos;
using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class RegisterUserResponse : BaseResponse
    {
        public UserDto? User { get; set; }

        public RegisterUserResponse(UserDto user)
        {
            User = user;
        }
        public RegisterUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
