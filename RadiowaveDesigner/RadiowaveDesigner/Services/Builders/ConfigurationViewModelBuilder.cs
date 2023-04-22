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
        var configs = await _configurationService.GetAll();
        var viewModel = new ConfigurationViewModel()
        {
           BaseStationConfiguration = configs.Select(BuildBaseStationConfig),
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
            Coordinates = null,
        };
    }
}