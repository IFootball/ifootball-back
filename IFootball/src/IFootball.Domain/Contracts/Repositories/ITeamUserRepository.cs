using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ITeamUserRepository
{
    Task CreateTeamUserAsync(TeamUser teamUser);
}