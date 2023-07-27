using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses;

public class DeletePlayerResponse : BaseResponse
{
    public DeletePlayerResponse(){}
    public DeletePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}