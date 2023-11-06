using RadiowaveDesigner.Infrastructure;
using RadiowaveDesigner.Modeling;
using RadiowaveDesigner.Services.AreaConfiguration;
using RadiowaveDesigner.Services.Builders;
using RadiowaveDesigner.Services.Calculations;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.Services.Hosted;
using RadiowaveDesigner.Services.Mappings;

namespace RadiowaveDesigner;

public static class RadiowaveDesignerModule
{
    internal static void AddRadiowaveDesignerModule(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddInfrastructureModule();
        services.AddModelingModule();

        services.AddTransient<IHomeViewModelBuilder, HomeViewModelBuilder>();
        services.AddTransient<IConfigurationViewModelBuilder, ConfigurationViewModelBuilder>();

        services.AddTransient<IConfigurationService, ConfigurationService>();
        services.AddTransient<IAreaConfigurationService, AreaConfigurationService>();
        services.AddTransient<IPropagationRangeCalculator, PropagationRangeCalculator>();
        services.AddTransient<IBaseStationViewModelMapper, BaseStationViewModelMapper>();
        services.AddTransient<IAreaConfigViewModelMapper, AreaConfigViewModelMapper>();
        services.AddTransient<IPlacesMapper, PlacesMapper>();
        services.AddTransient<IPlaceMapper, PlaceMapper>();
        services.AddTransient<ICategoryMapper, CategoryMapper>();
        services.AddHostedService<PlacesUpdatingHostedService>();
    }
}