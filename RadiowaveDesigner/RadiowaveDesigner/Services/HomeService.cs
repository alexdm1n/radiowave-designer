using Microsoft.Extensions.Options;
using RadiowaveDesigner.Settings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services;

internal class HomeService : IHomeService
{
    private readonly YandexApiSettings _yandexApiSettings;

    public HomeService(IOptions<YandexApiSettings> yandexApiSettings)
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