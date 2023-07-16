using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ITeamClassRepository
{
    Task<bool> ExistsTeamClassById(long id);
    Task<TeamClass?> FindById(long id);
    Task Delete(TeamClass teamClass);
    Task Register(TeamClass teamClass);
    Task Edit(TeamClass teamClass);
    Task<TeamClass?> FindCompleteById(long idTeamClass);
}