using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class YandexPlacesResponseMessage
{
    [JsonPropertyName("features")]
    public IEnumerable<PlacesResponse> Places { get; init; }
}