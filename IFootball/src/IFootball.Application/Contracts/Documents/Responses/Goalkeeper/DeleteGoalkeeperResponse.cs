using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses;

public class DeleteGoalkeeperResponse : BaseResponse
{
    public DeleteGoalkeeperResponse(){}
    public DeleteGoalkeeperResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}