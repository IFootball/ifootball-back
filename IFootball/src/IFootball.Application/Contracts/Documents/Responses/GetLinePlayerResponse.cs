using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetLinePlayerResponse : BaseResponse
{
    public LinePlayerDto? LinePlayerDto { get; set; }
    public GetLinePlayerResponse(LinePlayerDto linePlayer) 
    { 
        LinePlayerDto = linePlayer;
    }
    public GetLinePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}