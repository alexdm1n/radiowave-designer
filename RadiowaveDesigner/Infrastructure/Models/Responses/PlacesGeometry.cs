using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class PlacesGeometry
{
    [JsonPropertyName("coordinates")]
    public IEnumerable<double> Coordinates { get; init; }
}