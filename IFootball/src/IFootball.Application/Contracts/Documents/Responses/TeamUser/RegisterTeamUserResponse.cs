using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterTeamUserResponse : BaseResponse
{
    public SimpleTeamUserDto? SimpleTeamUser { get; set; }
    
    public RegisterTeamUserResponse(SimpleTeamUserDto simpleTeamUserDto) 
    { 
        SimpleTeamUser = simpleTeamUserDto;
    }
    
    public RegisterTeamUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }

}