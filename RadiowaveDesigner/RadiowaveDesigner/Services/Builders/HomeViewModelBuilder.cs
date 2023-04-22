using System.Text.Json;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.Services.Mappings;
using RadiowaveDesigner.Settings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class HomeViewModelBuilder : IHomeViewModelBuilder
{
    private readonly YandexApiSettings _yandexApiSettings;
    private readonly IBaseStationViewModelMapper _baseStationViewModelMapper;
    private readonly IConfigurationService _configurationService;

    public HomeViewModelBuilder(
        IOptions<YandexApiSettings> yandexApiSettings,
        IConfigurationService configurationService,
        IBaseStationViewModelMapper baseStationViewModelMapper)
    {
        _configurationService = configurationService;
        _baseStationViewModelMapper = baseStationViewModelMapper;
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public async Task<HomeViewModel> Get()
    {
        var configs = await _configurationService.GetAll();
        var configViewModels = configs.Select(c => _baseStationViewModelMapper.Map(c!));
        return new()
        {
            ApiKey = _yandexApiSettings.ApiKey,
            BaseStationViewModelsJson = Serialize(configViewModels),
        };
    }

    private string Serialize(IEnumerable<BaseStationViewModel> viewModels)
    {
        return JsonSerializer.Serialize(viewModels);
    }
}