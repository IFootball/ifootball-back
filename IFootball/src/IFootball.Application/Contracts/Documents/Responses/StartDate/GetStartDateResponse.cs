using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.StartDate;

namespace IFootball.Application.Contracts.Documents.Responses.StartDate;

public class GetStartDateResponse : BaseResponse
{
    public StartDateDto? StartDate { get; set; }
    
    public GetStartDateResponse(StartDateDto startDate) 
    { 
        StartDate = startDate;
    }
    
    public GetStartDateResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}