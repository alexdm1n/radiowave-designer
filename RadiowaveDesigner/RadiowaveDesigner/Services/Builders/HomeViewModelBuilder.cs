using System.Text.Json;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Models;
using RadiowaveDesigner.Settings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

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
            PropagationRange = 300,
            CoordinatesJson = GetCoordinatesJson(new[]
            {
                new CoordinatesModel(53.94294178325,27.610945550371945),
                new CoordinatesModel(53.8829441716099,27.4818561949032)
            })
        };
    }

    private string GetCoordinatesJson(IEnumerable<CoordinatesModel> coordinates)
    {
        return JsonSerializer.Serialize(coordinates);
    }
}