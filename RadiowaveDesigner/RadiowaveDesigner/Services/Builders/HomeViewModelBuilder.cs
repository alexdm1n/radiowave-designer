using System.Text.Json;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Models;
using RadiowaveDesigner.Services.Calculations;
using RadiowaveDesigner.Services.Configuration;
using RadiowaveDesigner.Services.Home;
using RadiowaveDesigner.Settings;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

internal class HomeViewModelBuilder : IHomeViewModelBuilder
{
    private readonly YandexApiSettings _yandexApiSettings;
    private readonly IPropagationRangeCalculator _propagationRangeCalculator;
    private readonly IHomeService _homeService;

    public HomeViewModelBuilder(
        IOptions<YandexApiSettings> yandexApiSettings,
        IPropagationRangeCalculator propagationRangeCalculator,
        IHomeService homeService)
    {
        _propagationRangeCalculator = propagationRangeCalculator;
        _homeService = homeService;
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public async Task<HomeViewModel> Get()
    {
        var propagationRange = await _propagationRangeCalculator.Calculate();
        var coordinates = await _homeService.GetCoordinates();
        return new()
        {
            ApiKey = _yandexApiSettings.ApiKey,
            PropagationRange = propagationRange,
            CoordinatesJson = coordinates == null ? null : GetCoordinatesJson(coordinates),
        };
    }

    private string? GetCoordinatesJson(IEnumerable<CoordinatesModel> coordinates)
    {
        return JsonSerializer.Serialize(coordinates);
    }
}