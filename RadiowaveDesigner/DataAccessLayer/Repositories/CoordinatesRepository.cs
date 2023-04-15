using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class CoordinatesRepository : ICoordinatesRepository
{
    private readonly AppDbContext _context;

    public CoordinatesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CoordinatesConfiguration>> GetAll()
    {
        return await _context.CoordinatesConfigurations.ToListAsync();
    }

    public async Task Add(CoordinatesConfiguration coordinatesConfiguration)
    {
        await _context.CoordinatesConfigurations.AddAsync(coordinatesConfiguration);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        _context.CoordinatesConfigurations.Remove(
            (await _context.CoordinatesConfigurations.SingleOrDefaultAsync(c => c.Id == id))!);
        await _context.SaveChangesAsync();
    }
}