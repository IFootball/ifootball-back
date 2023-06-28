using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class ClassRepository : BaseRepository, IClassRepository
    {
        private readonly DataContext _context;
        public ClassRepository(DataContext context, IConfiguration config) : base(config)
        {
            _context = context;
        }

        public async Task CreateClassAsync(Class newClass)
        {
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetAllAsync() => await _context.Classes.ToListAsync();

        public async Task<bool> ClassExists(string name) => await _context.Classes.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower())) is not null;
    }
}
