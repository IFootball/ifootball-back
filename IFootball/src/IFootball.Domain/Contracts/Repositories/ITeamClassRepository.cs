using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ITeamClassRepository
{
    Task<bool> ExistsTeamClassById(long id);
    Task Register(TeamClass teamClass);
}