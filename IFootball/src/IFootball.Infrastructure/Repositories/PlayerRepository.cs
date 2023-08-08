using IFootball.Core;
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

    public async Task<PagedResponse<Player>> FindAll(long? idGender, long? playerType, string name, Pageable pageable)
    {
        var query = _context.Players.AsQueryable();
        query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));

        if (idGender is not null) 
            query = query.Where(x => x.Gender.Id == idGender);
        
        if (playerType is not null) 
            query = query.Where(x => x.PlayerType == (PlayerType)playerType);
        
        return await PagedQuery.GetPagedResponse(query, pageable);
    }
    
    public async Task<Player?> FindById(long idPlayer) => await _context.Players.FindAsync(idPlayer);
    
    public async Task<Player?> FindCompleteById(long idPlayer) => await _context.Players
        .Where(x => x.Id == idPlayer)
        .Include(x => x.Gender)
        .Include(x => x.Goalkeeper)
        .FirstOrDefaultAsync();
}