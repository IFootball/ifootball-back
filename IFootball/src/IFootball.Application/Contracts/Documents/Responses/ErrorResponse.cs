using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class ErrorResponse
    {
        public string? Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public ErrorResponse(HttpStatusCode statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}