using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditTeamClassResponse : BaseResponse
{
    public CompleteTeamClassDto? CompleteTeamClass { get; set; }
    
    public EditTeamClassResponse(CompleteTeamClassDto completeTeamClass) 
    { 
        CompleteTeamClass = completeTeamClass;
    }
    
    public EditTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}