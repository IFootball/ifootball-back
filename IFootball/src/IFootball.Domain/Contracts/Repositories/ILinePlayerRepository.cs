using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ILinePlayerRepository
{
    Task CreateLinePlayer(LinePlayer linePlayer);
    Task EditLinePlayer(LinePlayer linePlayer);
    Task<LinePlayer?> FindById(long idLinePlayer);
    Task DeleteLinePlayer(LinePlayer linePlayer);
}