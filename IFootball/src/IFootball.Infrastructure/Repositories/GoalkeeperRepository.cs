using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class GoalkeeperRepository : BaseRepository, IGoalkeeperRepository
{
    private readonly DataContext _context;
    public GoalkeeperRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task<bool> ExistsById(long idGoalkeeper)
    {
        return await _context.Goalkeepers.FindAsync(idGoalkeeper) is not null;
    }
    
    public async Task<Goalkeeper> FindById(long idGoalkeeper)
    {
        return await _context.Goalkeepers
            .Where(x => x.Id == idGoalkeeper)
            .Include(x => x.Gender)
            .FirstOrDefaultAsync();    }
}