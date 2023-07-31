using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterPlayerResponse : BaseResponse
{
    public SimplePlayerDto? SimplePlayer { get; set; }
    public RegisterPlayerResponse(SimplePlayerDto simplePlayerDto) 
    { 
        SimplePlayer = simplePlayerDto;
    }
    public RegisterPlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}