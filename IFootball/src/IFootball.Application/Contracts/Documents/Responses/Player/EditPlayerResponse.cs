using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditPlayerResponse : BaseResponse
{
    public SimplePlayerDto? SimplePlayer { get; set; }
    public EditPlayerResponse(SimplePlayerDto simplePlayerDto) 
    {
        SimplePlayer = simplePlayerDto;
    }
    public EditPlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}