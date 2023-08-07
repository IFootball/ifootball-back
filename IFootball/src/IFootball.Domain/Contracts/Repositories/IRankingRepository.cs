using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IRankingRepository
{
    Task<PagedResponse<Player>> ListPlayerGeneral();
}