using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface ITeamUserService
{
     Task<RegisterTeamUserResponse> RegisterAsync(RegisterTeamUserRequest teamUserRequest, long idGender);
     Task<GetTeamUserResponse> GetAsync(long idGender);
}