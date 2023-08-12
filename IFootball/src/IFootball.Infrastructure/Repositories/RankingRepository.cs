using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
using IFootball.Domain.Contracts;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;
using IFootball.Infrastructure.Data;
using IFootball.Infrastructure.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class RankingRepository : BaseRepository, IRankingRepository
{
    private readonly DataContext _context;
    public RankingRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task<PagedResponse<ScorePlayer>> ListPlayerGeneral(long idGender, Pageable pageable)
    {
        var query = _context.Players
            .Include(x => x.Goalkeeper)
            .AsEnumerable()
            .Where(x => x.IdGender == idGender)
            .Select(x => new ScorePlayer(x))
            .OrderByDescending(x => x.Score);
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }
    
    public async Task<PagedResponse<ScoreTeamClass>> ListTeamClassScore(int idGender, Pageable pageable)
    {
        var query = _context.TeamClasses
            .Include(x => x.Class)
            .Include(x => x.TeamClassPlayers)
            .ThenInclude(x => x.Goalkeeper)
            .AsEnumerable()
            .Where(x => x.IdGender == idGender)
            .Select(x => new ScoreTeamClass(x))
            .OrderByDescending(x => x.Score);

        return await PagedQuery.GetPagedResponse(query, pageable);      
    }

    public async Task<PagedResponse<ScoreUser>> ListUserScore(int idGender, Pageable pageable)
    {
        var query = _context.Users
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.Goalkeeper.Goalkeeper)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.PlayerOne)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.PlayerTwo)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.PlayerThree)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.PlayerFour)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.ReservePlayerOne)
            .Include(x => x.UserTeamsUser)
                .ThenInclude(x => x.ReservePlayerTwo);

        var scoreUsers = query
            .AsEnumerable()
            .Select(x => new ScoreUser(x, idGender))
            .OrderByDescending(x => x.Score);

        return await PagedQuery.GetPagedResponse(scoreUsers, pageable);
    }

    public async Task<PagedResponse<Player>> ListGoalScore(int idGender, Pageable pageable)
    {
        var query = _context.Players
            .AsQueryable()
            .Where(x => x.Gender.Id == idGender)
            .OrderByDescending(x => x.Goals);

        return await PagedQuery.GetPagedResponse(query, pageable);    
    }

    public async Task<PagedResponse<Player>> ListAssistScore(int idGender, Pageable pageable)
    {
        var query = _context.Players
            .AsQueryable()
            .Where(x => x.Gender.Id == idGender)
            .OrderByDescending(x => x.Assists);

        return await PagedQuery.GetPagedResponse(query, pageable);    
    }

    public async Task<PagedResponse<Player>> ListDefenseScore(int idGender, Pageable pageable)
    {
        var query = _context.Players
            .AsQueryable()
            .Where(x => x.Gender.Id == idGender && x.PlayerType == PlayerType.Goalkeeper)
            .Include(x => x.Goalkeeper)
            .OrderByDescending(x => x.Goalkeeper.Saves);

        return await PagedQuery.GetPagedResponse(query, pageable);        
    }

}