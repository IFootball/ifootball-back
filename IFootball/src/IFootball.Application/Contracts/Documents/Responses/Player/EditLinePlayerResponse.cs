using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditLinePlayerResponse : BaseResponse
{
    public PlayerDto? LinePlayer { get; set; }
    public EditLinePlayerResponse(PlayerDto linePlayerDto) 
    { 
        LinePlayer = linePlayerDto;
    }
    public EditLinePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}