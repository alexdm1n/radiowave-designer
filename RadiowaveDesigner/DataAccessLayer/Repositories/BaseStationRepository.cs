using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class BaseStationRepository : IBaseStationRepository
{
    private readonly AppDbContext _context;

    public BaseStationRepository(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<BaseStationConfiguration?>> GetAll()
    {
        return await _context.BaseStationConfiguration.ToListAsync();
    }

    public async Task<BaseStationConfiguration?> Get(long id)
    {
        return await _context.BaseStationConfiguration.SingleOrDefaultAsync(c => c!.Id == id);
    }

    public async Task Create(BaseStationConfiguration configuration)
    {
        await _context.BaseStationConfiguration.AddAsync(configuration);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var config = await _context.BaseStationConfiguration.SingleOrDefaultAsync(c => c!.Id == id);
        _context.BaseStationConfiguration.Remove(config);
        await _context.SaveChangesAsync();
    }
}