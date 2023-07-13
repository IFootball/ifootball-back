using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IGoalkeeperRepository
{
    Task<bool> ExistsById(long idGoalkeeper);
    Task<Goalkeeper> FindById(long idGoalkeeper);

}