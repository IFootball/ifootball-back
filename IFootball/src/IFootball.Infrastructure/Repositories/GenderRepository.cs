using IFootball.Domain.Contracts.Repositories;
using IFootball.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class GenderRepository : BaseRepository, IGenderRepository
    {
        private readonly DataContext _context;
        public GenderRepository(DataContext context, IConfiguration config) : base(config)
        {
            _context = context;
        }
        
        public async Task<bool> ExistsGenderById(long idGender)
        {
            var gender = await _context.Genders.FindAsync(idGender);
            return gender is not null;
        }
    }
}
