using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.StartDate;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;

namespace IFootball.Application.Contracts.Documents.Responses.StartDate;

public class EditStartDateResponse : BaseResponse
{
    public StartDateDto? StartDate { get; set; }
    
    public EditStartDateResponse(StartDateDto startDate) 
    { 
        StartDate = startDate;
    }
    
    public EditStartDateResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}