using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class PlacesProperties
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("boundedBy")]
    public IEnumerable<IEnumerable<double>> BoundedBy { get; init; }
    
    [JsonPropertyName("CompanyMetaData")]
    public PlacesMetaData MetaData { get; init; }
}