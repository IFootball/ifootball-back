using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
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

    public async Task<Player> FindById(long idPlayer) => await _context.Players
            .Where(x => x.Id == idPlayer)
            .Include(x => x.Gender)
            .FirstOrDefaultAsync();
}