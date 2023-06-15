using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public bool isValid()
        {
            return true;
        }
        public BaseResponse() { }
        public BaseResponse(HttpStatusCode statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
