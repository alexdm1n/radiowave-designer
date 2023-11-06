using Microsoft.Extensions.Options;
using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Infrastructure.Settings;

namespace RadiowaveDesigner.Infrastructure.HttpClients.YandexPlacesApi;

internal class YandexPlacesHttpClient : IYandexPlacesHttpClient
{
    private readonly YandexApiSettings _yandexApiSettings;
    private readonly PlacesApiSettings _placesApiSettings;
    private readonly IIntegrationHttpClient _integrationHttpClient;

    public YandexPlacesHttpClient(
        IOptions<YandexApiSettings> yandexApiSettings,
        IOptions<PlacesApiSettings> placesApiSettings,
        IIntegrationHttpClient integrationHttpClient)
    {
        _integrationHttpClient = integrationHttpClient;
        _placesApiSettings = placesApiSettings.Value;
        _yandexApiSettings = yandexApiSettings.Value;
    }

    public async Task<YandexPlacesResponseMessage> GetPlaces(string objectType, int numberOfResults)
    {
        var queryParams = new Dictionary<string, string>
        {
            { "apikey", $"{_yandexApiSettings.PlacesApiKey}" },
            { "text", $"{objectType} {_placesApiSettings.Region}" },
            { "ll", "53.869248,27.441126" },
            { "spn", "53.884577,27.448886" },
            { "results", $"{numberOfResults}" },
            { "lang", "en_US" },
        };

        return await _integrationHttpClient.Get<YandexPlacesResponseMessage>(_placesApiSettings.BaseUrl, queryParams);
    }
}