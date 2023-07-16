using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditTeamClassResponse : BaseResponse
{
    public TeamClassDto? TeamClass { get; set; }
    
    public EditTeamClassResponse(TeamClassDto teamClass) 
    { 
        TeamClass = teamClass;
    }
    
    public EditTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}