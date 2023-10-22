using RadiowaveDesigner.Infrastructure.Models.Responses;

namespace RadiowaveDesigner.Infrastructure.HttpClients.YandexPlacesApi;

internal interface IYandexPlacesHttpClient
{
    Task<YandexPlacesResponseMessage> GetPlaces(string objectType, int numberOfResults);
}