using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface ITeamUserService
{
     Task<RegisterTeamUserResponse> RegisterMaleAsync(RegisterTeamUserRequest teamUserRequest);
     Task<RegisterTeamUserResponse> RegisterFemaleAsync(RegisterTeamUserRequest teamUserRequest);


}