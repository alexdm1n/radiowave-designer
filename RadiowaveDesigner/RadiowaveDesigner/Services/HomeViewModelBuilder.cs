using Microsoft.Extensions.Options;
using RadiowaveDesigner.Settings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services;

internal class HomeViewModelBuilder : IHomeViewModelBuilder
{
    private readonly YandexApiSettings _yandexApiSettings;

    public HomeViewModelBuilder(IOptions<YandexApiSettings> yandexApiSettings)
    {
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public HomeViewModel Get()
    {
        return new()
        {
            ApiKey = _yandexApiSettings.ApiKey,
        };
    }
}