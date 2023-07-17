﻿using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class LinePlayerRepository : BaseRepository, ILinePlayerRepository
{
    private readonly DataContext _context;
    public LinePlayerRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task CreateLinePlayer(Player linePlayer)
    {
        _context.LinePlayers.Add(linePlayer);
        await _context.SaveChangesAsync();
    }

    public async Task EditLinePlayer(Player linePlayer)
    {
        _context.LinePlayers.Update(linePlayer);
        await _context.SaveChangesAsync();    
    }

    public async Task DeleteLinePlayer(Player linePlayer)
    {
        _context.LinePlayers.Remove(linePlayer);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsById(long idLinePlayer)
    {
        return await _context.LinePlayers.FindAsync(idLinePlayer) is not null;
    }

    public async Task<Player> FindById(long idLinePlayer)
    {
        return await _context.LinePlayers
            .Where(x => x.Id == idLinePlayer)
            .Include(x => x.Gender)
            .FirstOrDefaultAsync();

    }
}