using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<Gender> FindByName(GenderName name)
        {
            return await _context.Genders.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
