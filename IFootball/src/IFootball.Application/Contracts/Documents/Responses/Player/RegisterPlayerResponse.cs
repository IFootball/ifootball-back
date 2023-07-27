using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterPlayerResponse : BaseResponse
{
    public PlayerDto? player { get; set; }
    public RegisterPlayerResponse(PlayerDto playerDto) 
    { 
        player = playerDto;
    }
    public RegisterPlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}