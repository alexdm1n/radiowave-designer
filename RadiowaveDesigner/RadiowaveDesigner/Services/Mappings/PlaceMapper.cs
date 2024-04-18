using System.Globalization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Infrastructure.Settings;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

internal class PlaceMapper : IPlaceMapper
{
    private readonly PlacesApiSettings _placesApiSettings;
    private readonly ICategoryMapper _categoryMapper;

    public PlaceMapper(IOptions<PlacesApiSettings> placesApiSettings, ICategoryMapper categoryMapper)
    {
        _categoryMapper = categoryMapper;
        _placesApiSettings = placesApiSettings.Value;
    }

    public Places Map(PlacesResponse response)
    {
        var latitude = response.Geometry.Coordinates.First().ToString(CultureInfo.InvariantCulture);
        var longitude = response.Geometry.Coordinates.Last().ToString(CultureInfo.InvariantCulture);
        return new()
        {
            Coordinates = $"{latitude},{longitude}",
            Name = response.Properties.Name,
            Address = response.Properties.MetaData.Address,
            BoundedByJson = JsonSerializer.Serialize(response.Properties.BoundedBy),
            Region = _placesApiSettings.Region,
            Priority = 0.75,
            Category = _categoryMapper.Map(response.Properties.MetaData.Categories.First().Name),
        };
    }
}