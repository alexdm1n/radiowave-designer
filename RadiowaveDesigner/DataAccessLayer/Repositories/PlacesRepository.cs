using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class PlacesRepository : IPlacesRepository
{
    private readonly AppDbContext _context;

    public PlacesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Exist(string region)
    {
        return (await _context.Places.ToListAsync()).Any(p => p.Region == region);
    }

    public async Task<IEnumerable<Places?>> GetAll()
    {
        return await _context.Places.ToListAsync();
    }

    public async Task<IEnumerable<Places>> GetByCategory(Category category)
    {
        return await _context.Places.Where(p => p.Category == category).ToListAsync();
    }

    public async Task Upsert(IList<Places> places)
    {
        await _context.AddRangeAsync(places);
        await _context.SaveChangesAsync();
    }
}