using System.Text.Json.Serialization;

namespace RadiowaveDesigner.Infrastructure.Models.Responses;

public class PlacesCategory
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
}