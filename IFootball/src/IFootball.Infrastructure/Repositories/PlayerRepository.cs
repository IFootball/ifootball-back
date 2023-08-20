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

public class PlayerRepository : BaseRepository, IPlayerRepository
{
    private readonly DataContext _context;
    public PlayerRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }

    public async Task EditPlayer(Player player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();    
    }

    public async Task DeletePlayer(Player player)
    {
        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsById(long idPlayer)
    {
        return await _context.Players.FindAsync(idPlayer) is not null;
    }

    public async Task<PagedResponse<Player>> FindAll(long? idGender, long? playerType, long? idTeamClass, string name, Pageable pageable)
    {
        var query = _context.Players.Include(x => x.TeamClass.Class).AsQueryable();
        query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));

        if (idGender is not null) 
            query = query.Where(x => x.Gender.Id == idGender);

        if (idTeamClass is not null)
            query = query.Where(x => x.IdTeamClass == idTeamClass);

        if (playerType is not null) 
            query = query.Where(x => x.PlayerType == (PlayerType)playerType);
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }

    public async Task<IEnumerable<long>> FindAllId(long? idGender, long? playerType, string? name)
    {
        var query = _context.Players.AsQueryable();
        query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));

        if (idGender is not null) 
            query = query.Where(x => x.Gender.Id == idGender);
        
        if (playerType is not null) 
            query = query.Where(x => x.PlayerType == (PlayerType)playerType);
        
        return await query.Select(x => x.Id).ToListAsync();    
    }

    public async Task<PagedResponse<ScorePlayer>> ListTeamClass(long idTeamClass, Pageable pageable)
    {
        var query = _context.Players
            .Include(x => x.Goalkeeper)
            .AsEnumerable()
            .Where(x => x.IdTeamClass == idTeamClass)
            .Select(x => new ScorePlayer(x))
            .OrderByDescending(x => x.Score);
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }

    public async Task<Player?> FindById(long idPlayer) => await _context.Players.FindAsync(idPlayer);
    
    public async Task<Player?> FindCompleteById(long idPlayer) => await _context.Players
        .Where(x => x.Id == idPlayer)
        .Include(x => x.TeamClass.Class)
        .Include(x => x.Gender)
        .Include(x => x.Goalkeeper)
        .FirstOrDefaultAsync();
}