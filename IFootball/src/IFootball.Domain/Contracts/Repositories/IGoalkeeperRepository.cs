using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IGoalkeeperRepository
{
    Task CreateGoalkeeper(Goalkeeper goalkeeper);
}