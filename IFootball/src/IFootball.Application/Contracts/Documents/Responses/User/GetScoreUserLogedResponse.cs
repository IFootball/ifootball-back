using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;

namespace IFootball.Application.Contracts.Documents.Responses.User;

public class GetScoreUserLogedResponse : BaseResponse
{ 
    public ScoreUserLogedDto? UserLoged { get; set; }

    public GetScoreUserLogedResponse(ScoreUserLogedDto user)
    {
        UserLoged = user;
    }
    public GetScoreUserLogedResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}