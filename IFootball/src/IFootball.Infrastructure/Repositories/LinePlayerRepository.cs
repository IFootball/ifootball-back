using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class LinePlayerRepository : BaseRepository, ILinePlayerRepository
{
    private readonly DataContext _context;
    public LinePlayerRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task CreateLinePlayer(LinePlayer linePlayer)
    {
        _context.LinePlayers.Add(linePlayer);
        await _context.SaveChangesAsync();
    }

    public async Task EditLinePlayer(LinePlayer linePlayer)
    {
        _context.LinePlayers.Update(linePlayer);
        await _context.SaveChangesAsync();    
    }

    public async Task<LinePlayer?> FindById(long idLinePlayer)
    {
        return await _context.LinePlayers.FindAsync(idLinePlayer);
    }

    public async Task DeleteLinePlayer(LinePlayer linePlayer)
    {
        _context.LinePlayers.Remove(linePlayer);
        await _context.SaveChangesAsync();    
    }
}