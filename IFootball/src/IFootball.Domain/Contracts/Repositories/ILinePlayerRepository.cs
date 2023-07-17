using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ILinePlayerRepository
{
    Task CreateLinePlayer(Player linePlayer);
    Task EditLinePlayer(Player linePlayer);
    Task<Player?> FindById(long idLinePlayer);
    Task DeleteLinePlayer(Player linePlayer);
    Task<bool> ExistsById(long idLinePlayer);
}