using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class EditTeamUserResponse : BaseResponse
{
    public TeamUserDto? TeamUser { get; set; }
    
    public EditTeamUserResponse(TeamUserDto teamUserDto) 
    { 
        TeamUser = teamUserDto;
    }
    
    public EditTeamUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}