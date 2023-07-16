namespace IFootball.Domain.Contracts.Repositories;

public interface ITeamClassRepository
{
    Task<bool> ExistsTeamClassById(long id);
}