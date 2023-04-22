using RadiowaveDesigner.Services.Builders;
using RadiowaveDesigner.Services.Calculations;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.Services.Mappings;

namespace RadiowaveDesigner;

public static class RadiowaveDesignerModule
{
    internal static void AddRadiowaveDesignerModule(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddTransient<IHomeViewModelBuilder, HomeViewModelBuilder>();
        services.AddTransient<IConfigurationViewModelBuilder, ConfigurationViewModelBuilder>();

        services.AddTransient<IConfigurationService, ConfigurationService>();
        services.AddTransient<IPropagationRangeCalculator, PropagationRangeCalculator>();
        services.AddTransient<IBaseStationViewModelMapper, BaseStationViewModelMapper>();
    }
}