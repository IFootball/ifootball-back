using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ILinePlayerRepository
{
    Task CreateLinePlayer(LinePlayer linePlayer);
}