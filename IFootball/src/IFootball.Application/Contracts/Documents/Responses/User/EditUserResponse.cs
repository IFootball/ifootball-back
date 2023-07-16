using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditUserResponse : BaseResponse
{
    public UserDto? User { get; set; }

    public EditUserResponse(UserDto user)
    {
        User = user;
    }
    public EditUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}