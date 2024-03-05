using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

internal class UserConfigurationRepository : IUserConfigurationRepository
{
    private readonly AppDbContext _context;

    public UserConfigurationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ShowExistingBaseStations()
    {
        var config = await _context.UserConfiguration.SingleOrDefaultAsync();
        if (config is null)
        {
            await UpsertBaseConfig();
            return false;
        }

        return config.ShowExistingBaseStations;
    }

    public async Task ChangeShowExistingBaseStationsStatus()
    {
        var config = await _context.UserConfiguration.SingleAsync();
        config!.ShowExistingBaseStations = !config.ShowExistingBaseStations;
        _context.UserConfiguration.Update(config);
        await _context.SaveChangesAsync();
    }

    private async Task UpsertBaseConfig()
    {
        var config = new UserConfiguration
        {
            ShowExistingBaseStations = false,
        };

        await _context.UserConfiguration.AddAsync(config);
        await _context.SaveChangesAsync();
    }
}