using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class ConfigurationViewModelBuilder : IConfigurationViewModelBuilder
{
    private readonly IConfigurationService _configurationService;

    public ConfigurationViewModelBuilder(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    public async Task<ConfigurationViewModel> Build()
    {
        var config = await _configurationService.GetBaseStationConfig();
        var coordinates = await _configurationService.GetCoordinates();
        
        var viewModel = new ConfigurationViewModel()
        {
           BaseStationConfiguration = BuildBaseStationConfig(config),
           CoordinatesConfigurations = coordinates,
        };

        return viewModel;
    }

    private BaseStationConfiguration BuildBaseStationConfig(BaseStationConfiguration? configuration)
    {
        if (configuration != null)
        {
            return configuration;
        }

        return new()
        {
            FrequencyInHz = 0,
            Height = 0,
        };
    }
}