using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class GoalkeeperRepository : BaseRepository, IGoalkeeperRepository
{
    private readonly DataContext _context;
    public GoalkeeperRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }

    public async Task CreateGoalkeeper(Goalkeeper goalkeeper)
    {
        _context.Goalkeepers.Add(goalkeeper);
        await _context.SaveChangesAsync();
    }
}