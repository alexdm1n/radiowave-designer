using DataAccessLayer.Repositories;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Infrastructure.Constants;
using RadiowaveDesigner.Infrastructure.HttpClients.YandexPlacesApi;
using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Infrastructure.Settings;
using RadiowaveDesigner.Services.Mappings;

namespace RadiowaveDesigner.Services.Hosted;

public class PlacesUpdatingHostedService : IHostedService
{
    private readonly IPlacesRepository _placesRepository;
    private readonly PlacesApiSettings _placesApiSettings;
    private readonly IYandexPlacesHttpClient _yandexPlacesHttpClient;
    private readonly IPlacesMapper _placesMapper;

    public PlacesUpdatingHostedService(
        IPlacesRepository placesRepository,
        IOptions<PlacesApiSettings> placesApiSettings,
        IYandexPlacesHttpClient yandexPlacesHttpClient,
        IPlacesMapper placesMapper)
    {
        _placesRepository = placesRepository;
        _placesApiSettings = placesApiSettings.Value;
        _yandexPlacesHttpClient = yandexPlacesHttpClient;
        _placesMapper = placesMapper;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (await _placesRepository.Exist(_placesApiSettings.Region))
        {
            return;
        }

        var responseMessages = new List<PlacesResponse>();
        foreach (var place in PlacesConstants.PlacesQueries)
        {
            var response = await _yandexPlacesHttpClient.GetPlaces(place.Key, place.Value);
            responseMessages.AddRange(response.Places);
        }

        var places = _placesMapper.Map(responseMessages);
        var uniquePlaces = places.DistinctBy(p => p.Coordinates).ToList();
        await _placesRepository.Upsert(uniquePlaces);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}