using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterTeamClassResponse : BaseResponse
{
    public TeamClassDto? TeamClass { get; set; }
    
    public RegisterTeamClassResponse(TeamClassDto teamClass) 
    { 
        TeamClass = teamClass;
    }
    
    public RegisterTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}