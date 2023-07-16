using System.Drawing;
using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class DeleteUserResponse : BaseResponse
    {
        public DeleteUserResponse(){}
        public DeleteUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
