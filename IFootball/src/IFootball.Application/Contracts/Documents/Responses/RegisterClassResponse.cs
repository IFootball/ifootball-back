using IFootball.Application.Contracts.Documents.Dtos;
using System.Net;


namespace IFootball.Application.Contracts.Documents.Responses
{
    public class RegisterClassResponse : BaseResponse
    {
        public ClassDto? Class { get; set; }
        public RegisterClassResponse(ClassDto classDto) 
        { 
            Class = classDto;
        }
        public RegisterClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
