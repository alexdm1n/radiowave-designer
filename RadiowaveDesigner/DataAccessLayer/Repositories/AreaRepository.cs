using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class AreaRepository : IAreaRepository
{
    private readonly AppDbContext _context;

    public AreaRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<AreaConfiguration?> Get()
    {
        return await _context.AreaConfigurations
            .Include(c => c.Coordinates)
            .SingleOrDefaultAsync();
    }

    public async Task Upsert(AreaConfiguration configurations)
    {
        await _context.AddAsync(configurations);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAll()
    {
        var existingConfigs = await _context.AreaConfigurations
            .Include(c => c.Coordinates)
            .ToListAsync();
        if (existingConfigs.Any())
        {
            _context.AreaConfigurations.RemoveRange(existingConfigs);
            await _context.SaveChangesAsync();
        }
    }
}