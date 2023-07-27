using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses;

public class DeleteLinePlayerResponse : BaseResponse
{
    public DeleteLinePlayerResponse(){}
    public DeleteLinePlayerResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}