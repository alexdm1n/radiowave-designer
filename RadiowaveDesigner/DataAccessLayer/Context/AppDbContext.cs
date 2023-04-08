using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Context;

public sealed class AppDbContext : DbContext
{
    public DbSet<BaseStationConfiguration> BaseStationConfiguration { get; set; }
    
    public DbSet<CoordinatesConfiguration> CoordinatesConfigurations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}