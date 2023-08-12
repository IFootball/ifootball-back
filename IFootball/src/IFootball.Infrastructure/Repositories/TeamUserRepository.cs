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

        public async Task<TeamUser?> FindTeamUserByIdUserAndIdGender(long idUser, long idGender)
        {
            return await _context.TeamUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdUser == idUser && x.IdGender == idGender);

        }

        public async Task EditTeamUserAsync(TeamUser teamUser)
        {
            _context.TeamUsers.Update(teamUser);
            await _context.SaveChangesAsync();        
        }

        public async Task<TeamUser?> FindCompleteTeamUserByIdUserAndIdGender(long idUser, long idGender)
        {
            return await _context.TeamUsers
                .AsNoTracking()
                .Where(x => x.IdUser == idUser && x.IdGender == idGender)
                .Include(x => x.Gender)
                .Include(x => x.Goalkeeper)
                .Include(x => x.PlayerOne)
                .Include(x => x.PlayerTwo)
                .Include(x => x.PlayerThree)
                .Include(x => x.PlayerFour)
                .Include(x => x.ReservePlayerOne)
                .Include(x => x.ReservePlayerTwo)
                .FirstOrDefaultAsync();
        }
    }
}
