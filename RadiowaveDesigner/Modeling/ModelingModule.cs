using Microsoft.Extensions.DependencyInjection;
using RadiowaveDesigner.Modeling.Automation;
using RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;

namespace RadiowaveDesigner.Modeling;

public static class ModelingModule
{
    public static void AddModelingModule(this IServiceCollection services)
    {
        services.AddTransient<ISuiModelCalculator, SuiModelCalculator>();

        services.AddTransient<IBaseStationsFinder, BaseStationsFinder>();
        services.AddTransient<IBaseStationsAutomationService, BaseStationsAutomationService>();
        services.AddTransient<IPlacesFinder, PlacesFinder>();
        services.AddTransient<IPrioritizedPlacesBaseStationCreator, PrioritizedPlacesBaseStationCreator>();
        services.AddTransient<IAutomatedPlacementService, AutomatedPlacementService>();
        services.AddTransient<IPlacesDeduplicator, PlacesDeduplicator>();
        services.AddTransient<IBaseStationsAutomatedCreator, BaseStationsAutomatedCreator>();
        services.AddTransient<IAutomatedBaseStationsFilter, AutomatedBaseStationsFilter>();
    }
}