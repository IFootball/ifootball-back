using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface ITeamClassService
{
    Task<RegisterTeamClassResponse> RegisterAsync(RegisterTeamClassRequest request);
}