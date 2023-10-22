using System.Text.Json;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Infrastructure.Settings;
using RadiowaveDesigner.Services.AreaConfiguration;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.Services.Mappings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class HomeViewModelBuilder : IHomeViewModelBuilder
{
    private readonly YandexApiSettings _yandexApiSettings;
    private readonly IBaseStationViewModelMapper _baseStationViewModelMapper;
    private readonly IAreaConfigurationService _areaConfigurationService;
    private readonly IConfigurationService _configurationService;
    private readonly IAreaConfigViewModelMapper _areaConfigViewModelMapper;

    public HomeViewModelBuilder(
        IOptions<YandexApiSettings> yandexApiSettings,
        IConfigurationService configurationService,
        IBaseStationViewModelMapper baseStationViewModelMapper,
        IAreaConfigurationService areaConfigurationService,
        IAreaConfigViewModelMapper areaConfigViewModelMapper)
    {
        _configurationService = configurationService;
        _baseStationViewModelMapper = baseStationViewModelMapper;
        _areaConfigurationService = areaConfigurationService;
        _areaConfigViewModelMapper = areaConfigViewModelMapper;
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public async Task<HomeViewModel> Get()
    {
        var configs = await _configurationService.GetAll();
        var configViewModels = configs.Select(c => _baseStationViewModelMapper.Map(c!));
        var areaConfig = await _areaConfigurationService.GetAll();
        var areaViewModels = areaConfig.Any()
            ? areaConfig.Select(ac => _areaConfigViewModelMapper.Map(ac.Coordinates)) 
            : null;
        return new()
        {
            ApiKey = _yandexApiSettings.ApiKey,
            BaseStationViewModelsJson = JsonSerializer.Serialize(configViewModels),
            AreaCoordinatesViewModelJson = areaViewModels != null ? JsonSerializer.Serialize(areaViewModels) : null,
        };
    }
}