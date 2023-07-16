using IFootball.Domain.Contracts.Repositories;
using IFootball.Infrastructure.Data;
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
}