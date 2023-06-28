using IFootball.Domain.Models;
using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class ListClassesResponse : BaseResponse
    {
        public IEnumerable<Class>? Classes { get; set; }

        public ListClassesResponse(IEnumerable<Class> classes)
        {
            Classes = classes;
        }

        public ListClassesResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
