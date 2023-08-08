using IFootball.Core;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using IFootball.Infrastructure.Repositories.Helpers;
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
        var query = _context.Players.AsQueryable();

        query = query
            .Where(x => x.Gender.Id == idGender)
            .OrderByDescending(x => 
                (x.Assists * 5) +
                (x.Goals * 8) +
                (x.YellowCard * -2) +
                (x.RedCard * -4) +
                (x.Fouls * -1) +
                (x.Wins * 1)
            );
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }
}