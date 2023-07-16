using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetGoalkeeperResponse : BaseResponse
{
    public GoalkeeperDto? Goalkeeper { get; set; }
    public GetGoalkeeperResponse(GoalkeeperDto goalkeeper) 
    { 
        Goalkeeper = goalkeeper;
    }
    public GetGoalkeeperResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}