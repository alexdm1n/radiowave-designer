using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class BaseStationRepository : IBaseStationRepository
{
    private readonly AppDbContext _context;

    public BaseStationRepository(AppDbContext context)
    {
        _context = context;
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

    public async Task UpsertList(IEnumerable<BaseStationConfiguration> configurations)
    {
        await _context.AddRangeAsync(configurations);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var config = await _context.BaseStationConfiguration.SingleOrDefaultAsync(c => c!.Id == id);
        _context.BaseStationConfiguration.Remove(config);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeFrequency(int frequency, bool existing)
    {
        var stationsToUpdate = await _context.BaseStationConfiguration
            .Where(c => c.Existing == existing)
            .ToListAsync();

        foreach (var station in stationsToUpdate)
        {
            station.FrequencyInMHz = frequency;
            _context.Entry(station).State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();
    }
}