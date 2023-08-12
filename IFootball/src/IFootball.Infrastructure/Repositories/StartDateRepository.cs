using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories;

public class StartDateRepository : BaseRepository, IStartDateRepository
{
    private readonly DataContext _context;
    public StartDateRepository(DataContext context, IConfiguration config) : base(config)
    {
        _context = context;
    }
    
    public async Task Edit(StartDate startDate)
    {
        _context.StartDates.Update(startDate);
        await _context.SaveChangesAsync();
    }

    public async Task<StartDate?> FindStarDate()
    {
        return await _context.StartDates.FirstOrDefaultAsync();
    }

    public async Task Register(StartDate startDate)
    {
        _context.StartDates.Add(startDate);
        await _context.SaveChangesAsync();
    }
}