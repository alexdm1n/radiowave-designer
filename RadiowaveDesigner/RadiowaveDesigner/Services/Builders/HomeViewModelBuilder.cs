using System.Text.Json;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Infrastructure.Settings;
using RadiowaveDesigner.Services.AreaConfiguration;
using RadiowaveDesigner.Services.BaseStations;
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
    private readonly IUserConfigurationRepository _userConfigurationRepository;
    private readonly IBaseStationFilter _baseStationFilter;

    public HomeViewModelBuilder(
        IOptions<YandexApiSettings> yandexApiSettings,
        IConfigurationService configurationService,
        IBaseStationViewModelMapper baseStationViewModelMapper,
        IAreaConfigurationService areaConfigurationService,
        IAreaConfigViewModelMapper areaConfigViewModelMapper,
        IUserConfigurationRepository userConfigurationRepository,
        IBaseStationFilter baseStationFilter)
    {
        _configurationService = configurationService;
        _baseStationViewModelMapper = baseStationViewModelMapper;
        _areaConfigurationService = areaConfigurationService;
        _areaConfigViewModelMapper = areaConfigViewModelMapper;
        _userConfigurationRepository = userConfigurationRepository;
        _baseStationFilter = baseStationFilter;
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public async Task<HomeViewModel> Get()
    {
        var showExistingBaseStations = await _userConfigurationRepository.ShowExistingBaseStations();
        var baseStations = (await _configurationService.GetAll()).ToList();
        var filteredBaseStations = _baseStationFilter.Filter(baseStations!, showExistingBaseStations);
        var baseStationsViewModels = filteredBaseStations.Select(c => _baseStationViewModelMapper.Map(c));
        var areaConfig = await _areaConfigurationService.Get();
        var areaViewModel = areaConfig is not null
            ? _areaConfigViewModelMapper.Map(areaConfig.Coordinates) 
            : null;

        return new()
        {
            ApiKey = _yandexApiSettings.ApiKey,
            BaseStationViewModelsJson = JsonSerializer.Serialize(baseStationsViewModels),
            AreaCoordinatesViewModelJson = (areaViewModel != null ? JsonSerializer.Serialize(areaViewModel) : null)!,
            ShowExistingBaseStations = showExistingBaseStations,
        };
    }
}