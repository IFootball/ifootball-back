using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
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

    public async Task<PagedResponse<Player>> ListPlayerGeneral(long idGender, Pageable pageable)
    {
        var query = _context.Players
            .AsQueryable()
            .Where(x => x.Gender.Id == idGender)
            .OrderByDescending(x => x.GetScore());
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }
    
    public async Task<PagedResponse<TeamClass>> ListTeamClassScore(int idGender, Pageable pageable)
    {
        var query = _context.TeamClasses
                .AsQueryable()
                .Where(x => x.Gender.Id == idGender)
                .Include(x => x.Class)
                .OrderByDescending(x => x.GetScore());

        return await PagedQuery.GetPagedResponse(query, pageable);      
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