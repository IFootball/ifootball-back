using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IGoalkeeperRepository
{
    Task CreateGoalkeeper(Goalkeeper goalkeeper);
    Task EditGoalkeeper(Goalkeeper goalkeeper);
    Task<Goalkeeper?> FindById(long idGoalkeeper);
    Task DeleteGoalkeeper(Goalkeeper goalkeeper);
}