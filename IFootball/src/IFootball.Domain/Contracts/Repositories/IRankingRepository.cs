using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IRankingRepository
{
    Task<PagedResponse<ScorePlayer>> ListPlayerGeneral(long idGender, Pageable pageable);
    Task<PagedResponse<Player>> ListGoalScore(int idGender, Pageable pageable);
    Task<PagedResponse<Player>> ListAssistScore(int idGender, Pageable pageable);
    Task<PagedResponse<Player>> ListDefenseScore(int idGender, Pageable pageable);
    Task<PagedResponse<ScoreTeamClass>> ListTeamClassScore(int idGender, Pageable pageable);
    Task<PagedResponse<ScoreUser>> ListUserScore(int idGender, Pageable pageable);
}