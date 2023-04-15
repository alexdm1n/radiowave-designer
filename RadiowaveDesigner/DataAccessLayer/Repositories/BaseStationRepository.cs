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

    public async Task<BaseStationConfiguration?> Get()
    {
        return await _context.BaseStationConfiguration.SingleOrDefaultAsync();
    }

    public async Task Update(BaseStationConfiguration configuration)
    {
        _context.Update(configuration);
        await _context.SaveChangesAsync();
    }

    public async Task Create(BaseStationConfiguration configuration)
    {
        await _context.BaseStationConfiguration.AddAsync(configuration);
        await _context.SaveChangesAsync();
    }
}