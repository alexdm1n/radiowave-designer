using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DataAccessLayerModule
{
    public static void AddDataAccessLayerModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnectionString");
        services
            .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

        services.AddTransient<IBaseStationRepository, BaseStationRepository>();
        services.AddTransient<IAreaRepository, AreaRepository>();
    }
}