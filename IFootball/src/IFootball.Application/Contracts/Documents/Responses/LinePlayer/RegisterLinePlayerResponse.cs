using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterLinePlayerResponse : BaseResponse
{
    public LinePlayerDto? LinePlayer { get; set; }
    public RegisterLinePlayerResponse(LinePlayerDto linePlayerDto) 
    { 
        LinePlayer = linePlayerDto;
    }
    public RegisterLinePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}