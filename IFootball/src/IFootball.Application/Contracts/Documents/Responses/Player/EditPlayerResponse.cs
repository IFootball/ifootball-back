using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditPlayerResponse : BaseResponse
{
    public PlayerDto? Player { get; set; }
    public EditPlayerResponse(PlayerDto playerDto) 
    {
        Player = playerDto;
    }
    public EditPlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}