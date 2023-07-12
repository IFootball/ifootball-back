using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class GoalkeeperRepository : BaseRepository, IGoalkeeperRepository
    {
        private readonly DataContext _context;

        public GoalkeeperRepository(IConfiguration config, DataContext context) : base(config)
        {
            _context = context;
        }

        public async Task<IList<Goalkeeper>> ListGoalkeeperAsync(long id, int pageNumber, int pageSize)
        {
            var query = _context.Goalkeepers
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
