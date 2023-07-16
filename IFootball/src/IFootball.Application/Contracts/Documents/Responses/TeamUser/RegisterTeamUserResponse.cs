using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class RegisterTeamUserResponse : BaseResponse
{
    public TeamUserDto? TeamUser { get; set; }
    
    public RegisterTeamUserResponse(TeamUserDto teamUserDto) 
    { 
        TeamUser = teamUserDto;
    }
    
    public RegisterTeamUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }

}