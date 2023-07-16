using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses;

public class GetTeamUserResponse : BaseResponse
{
    public CompleteTeamUserDto? CompleteTeamUser { get; set; }
    
    public GetTeamUserResponse(CompleteTeamUserDto completeTeamUserDto) 
    { 
        CompleteTeamUser = completeTeamUserDto;
    }
    
    public GetTeamUserResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}