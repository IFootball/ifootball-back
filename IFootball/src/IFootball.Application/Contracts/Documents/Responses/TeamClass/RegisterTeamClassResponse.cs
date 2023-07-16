using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterTeamClassResponse : BaseResponse
{
    public CompleteTeamClassDto? CompleteTeamClass { get; set; }
    
    public RegisterTeamClassResponse(CompleteTeamClassDto completeTeamClass) 
    { 
        CompleteTeamClass = completeTeamClass;
    }
    
    public RegisterTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}