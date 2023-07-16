using System.Net;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetTeamClassResponse : BaseResponse
{
    public TeamClassDto? TeamClass { get; set; }
    
    public GetTeamClassResponse(TeamClassDto teamClass) 
    { 
        TeamClass = teamClass;
    }
    
    public GetTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}