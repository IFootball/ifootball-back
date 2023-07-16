using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterGoalkeeperResponse : BaseResponse
{
    public GoalkeeperDto? Goalkeeper { get; set; }
    public RegisterGoalkeeperResponse(GoalkeeperDto goalkeeperDto) 
    { 
        Goalkeeper = goalkeeperDto;
    }
    public RegisterGoalkeeperResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}