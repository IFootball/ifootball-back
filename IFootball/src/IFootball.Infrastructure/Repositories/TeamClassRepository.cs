using IFootball.Domain.Contracts;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using IFootball.Infrastructure.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class TeamClassRepository : BaseRepository, ITeamClassRepository
{
    private readonly DataContext _context;
    public TeamClassRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task<bool> ExistsTeamClassById(long id)
    {
        return await _context.TeamClasses.FindAsync(id) is not null;
    }

    public async Task<TeamClass?> FindById(long id)
    {
        return await _context.TeamClasses
            .Include(x => x.Class)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Delete(TeamClass teamClass)
    {
        _context.TeamClasses.Remove(teamClass);
        await _context.SaveChangesAsync();
    }

    public async Task Register(TeamClass teamClass)
    {
        _context.TeamClasses.Add(teamClass);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(TeamClass teamClass)
    {
        _context.TeamClasses.Update(teamClass);
        await _context.SaveChangesAsync();    
    }

    public async Task<TeamClass?> FindCompleteById(long idTeamClass)
    {
        return await _context.TeamClasses
            .Where(x => x.Id == idTeamClass)
            .Include(x => x.TeamClassPlayers)
            .Include(x => x.Class)
            .FirstOrDefaultAsync();
    }

    public async Task<PagedResponse<TeamClass>> ListAsync(Pageable pageable)
    {
        var query = _context.TeamClasses
            .Include(x => x.Class)
            .AsEnumerable();
        
        return await PagedQuery.GetPagedResponse(query, pageable);

    }
}