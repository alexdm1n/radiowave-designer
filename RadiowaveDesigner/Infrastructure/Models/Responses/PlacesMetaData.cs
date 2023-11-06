using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class PlacesMetaData
{
    [JsonPropertyName("Categories")]
    public IEnumerable<PlacesCategory> Categories { get; init; }
    
    [JsonPropertyName("address")]
    public string Address { get; init; }
}