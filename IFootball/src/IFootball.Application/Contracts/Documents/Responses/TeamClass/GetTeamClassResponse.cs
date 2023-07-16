using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetTeamClassResponse : BaseResponse
{
    public CompleteTeamClassDto? CompleteTeamClass { get; set; }
    
    public GetTeamClassResponse(CompleteTeamClassDto completeTeamClass) 
    { 
        CompleteTeamClass = completeTeamClass;
    }
    
    public GetTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}