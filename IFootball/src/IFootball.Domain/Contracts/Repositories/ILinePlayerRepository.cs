using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface ILinePlayerRepository
{
    Task<bool> ExistsById(long idLinePlayer);
    Task<LinePlayer> FindById(long idLinePlayer);

}