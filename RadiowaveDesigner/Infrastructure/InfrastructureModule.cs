using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RadiowaveDesigner.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    public static IServiceCollection RegisterSettings<T>(this IServiceCollection services) where T : class
    {
        services.AddOptions<T>().Configure((Action<T, IConfiguration>)
            ((settings, configuration) => configuration.GetSection(typeof (T).Name).Bind(settings)));
        return services;
    }
}