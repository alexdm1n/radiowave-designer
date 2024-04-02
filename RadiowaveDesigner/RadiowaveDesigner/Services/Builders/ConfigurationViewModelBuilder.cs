using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.Services.AreaConfiguration;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class ConfigurationViewModelBuilder : IConfigurationViewModelBuilder
{
    private readonly IConfigurationService _configurationService;
    private readonly IAreaConfigurationService _areaConfigurationService;
    private readonly IUserConfigurationRepository _userConfigurationRepository;

    public ConfigurationViewModelBuilder(
        IConfigurationService configurationService,
        IAreaConfigurationService areaConfigurationService,
        IUserConfigurationRepository userConfigurationRepository)
    {
        _configurationService = configurationService;
        _areaConfigurationService = areaConfigurationService;
        _userConfigurationRepository = userConfigurationRepository;
    }

    public async Task<ConfigurationViewModel> Build()
    {
        var baseStationConfigurations = await _configurationService.GetAll();
        var areaConfiguration = await _areaConfigurationService.Get();
        var viewModel = new ConfigurationViewModel
        {
           BaseStationConfiguration = baseStationConfigurations.Select(BuildBaseStationConfig),
           AreaConfiguration = BuildAreaConfig(areaConfiguration),
           ShowExistingBaseStations = await _userConfigurationRepository.ShowExistingBaseStations(),
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