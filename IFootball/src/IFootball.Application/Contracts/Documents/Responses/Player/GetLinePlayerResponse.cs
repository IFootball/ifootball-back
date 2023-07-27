using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetLinePlayerResponse : BaseResponse
{
    public PlayerDto? LinePlayerDto { get; set; }
    public GetLinePlayerResponse(PlayerDto linePlayer) 
    { 
        LinePlayerDto = linePlayer;
    }
    public GetLinePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}