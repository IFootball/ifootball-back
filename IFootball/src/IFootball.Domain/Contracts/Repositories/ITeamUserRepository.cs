using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ITeamUserRepository
{
    Task CreateTeamUserAsync(TeamUser teamUser);
    Task<TeamUser?> FindTeamUserByIdUserAndIdGender(long idUser, long idGender);
    Task EditTeamUserAsync(TeamUser teamUser);

    Task<TeamUser?> FindCompleteTeamUserByIdUserAndIdGender(long idUser, long idGender);
}