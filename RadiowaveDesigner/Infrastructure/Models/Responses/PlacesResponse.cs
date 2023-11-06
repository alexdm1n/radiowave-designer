using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class PlacesResponse
{
    [JsonPropertyName("geometry")]
    public PlacesGeometry Geometry { get; init; }
    
    [JsonPropertyName("properties")]
    public PlacesProperties Properties { get; init; }
}