using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class TeamUserRepository : BaseRepository, ITeamUserRepository
    {
        private readonly DataContext _context;
        public TeamUserRepository(DataContext context, IConfiguration config) : base(config)
        {
            _context = context;
        }


        public async Task CreateTeamUserAsync(TeamUser teamUser)
        {
            _context.TeamUsers.Add(teamUser);
            await _context.SaveChangesAsync();
        }
    }
}
