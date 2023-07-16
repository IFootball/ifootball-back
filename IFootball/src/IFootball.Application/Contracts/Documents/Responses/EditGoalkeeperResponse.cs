using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditGoalkeeperResponse : BaseResponse
{
    public GoalkeeperDto? Goalkeeper { get; set; }
    public EditGoalkeeperResponse(GoalkeeperDto goalkeeperDto) 
    { 
        Goalkeeper = goalkeeperDto;
    }
    public EditGoalkeeperResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}