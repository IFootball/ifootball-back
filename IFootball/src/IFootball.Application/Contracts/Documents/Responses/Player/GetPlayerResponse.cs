using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetPlayerResponse : BaseResponse
{
    public CompletePlayerDto? CompletePlayerDto { get; set; }
    public GetPlayerResponse(CompletePlayerDto CompletePlayer) 
    { 
        CompletePlayerDto = CompletePlayer;
    }
    public GetPlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}