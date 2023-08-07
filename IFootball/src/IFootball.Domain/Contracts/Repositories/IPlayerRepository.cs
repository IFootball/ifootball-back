using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IPlayerRepository
{
    Task CreatePlayer(Player player);
    Task EditPlayer(Player player);
    Task<Player?> FindCompleteById(long idPlayer);
    Task<Player?> FindById(long idPlayer);

    Task DeletePlayer(Player player);
    Task<bool> ExistsById(long idPlayer);
    Task<PagedResponse<Player>> FindAll(long? idGender, long? playerType, string name, Pageable pageable);

}