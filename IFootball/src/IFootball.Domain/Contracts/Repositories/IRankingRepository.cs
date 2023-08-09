using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IRankingRepository
{
    Task<PagedResponse<Player>> ListPlayerGeneral(long idGender, Pageable pageable);
    Task<PagedResponse<Player>> ListGoalScore(int idGender, Pageable pageable);
    Task<PagedResponse<Player>> ListAssistsScore(int idGender, Pageable pageable);
}