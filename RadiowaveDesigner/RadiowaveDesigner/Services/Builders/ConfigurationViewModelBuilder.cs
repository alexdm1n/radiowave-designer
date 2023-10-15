using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.Services.AreaConfiguration;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class ConfigurationViewModelBuilder : IConfigurationViewModelBuilder
{
    private readonly IConfigurationService _configurationService;
    private readonly IAreaConfigurationService _areaConfigurationService;

    public ConfigurationViewModelBuilder(
        IConfigurationService configurationService,
        IAreaConfigurationService areaConfigurationService)
    {
        _configurationService = configurationService;
        _areaConfigurationService = areaConfigurationService;
    }

    public async Task<ConfigurationViewModel> Build()
    {
        var baseStationConfigurations = await _configurationService.GetAll();
        var areaConfigurations = await _areaConfigurationService.GetAll();
        var viewModel = new ConfigurationViewModel
        {
           BaseStationConfiguration = baseStationConfigurations.Select(BuildBaseStationConfig),
           AreaConfigurations = areaConfigurations.Select(BuildAreaConfig),
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
            FrequencyInMHz = 0,
            Height = 0,
            Coordinates = null,
        };
    }

    private Models.Models.AreaConfiguration BuildAreaConfig(Models.Models.AreaConfiguration? configuration)
    {
        if (configuration != null)
        {
            return configuration;
        }

        return new()
        {
            Coordinates = null,
        };
    }
}