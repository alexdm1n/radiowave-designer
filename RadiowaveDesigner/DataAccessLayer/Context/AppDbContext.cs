﻿using Microsoft.EntityFrameworkCore;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Context;

public sealed class AppDbContext : DbContext
{
    public DbSet<BaseStationConfiguration?> BaseStationConfiguration { get; set; }
    
    public DbSet<AreaConfiguration?> AreaConfigurations { get; set; }
    
    public DbSet<Places?> Places { get; set; }
    
    public DbSet<UserConfiguration?> UserConfiguration { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}