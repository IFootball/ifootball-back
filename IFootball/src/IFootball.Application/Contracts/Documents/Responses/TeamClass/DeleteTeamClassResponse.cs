using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Contracts.Documents.Responses;

public class DeleteTeamClassResponse : BaseResponse
{
    public DeleteTeamClassResponse() { }
    
    public DeleteTeamClassResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
}