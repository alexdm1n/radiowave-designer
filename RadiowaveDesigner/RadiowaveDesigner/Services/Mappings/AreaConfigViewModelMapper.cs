using System.Globalization;
using RadiowaveDesigner.Models;
using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Mappings;

internal class AreaConfigViewModelMapper : IAreaConfigViewModelMapper
{
    public AreaConfigViewModel Map(IEnumerable<Coordinate> coordinates)
    {
        return new()
        {
            Coordinates = coordinates.Select(SplitToModel),
        };
    }

    private static CoordinatesModelWithPosition SplitToModel(Coordinate coordinate)
    {
        var parts = coordinate.Coordinates.Split(',');

        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        if (double.TryParse(parts[0], CultureInfo.InvariantCulture, out var latitude) &&
            double.TryParse(parts[1], CultureInfo.InvariantCulture, out var longitude))
        {
            return new CoordinatesModelWithPosition(latitude, longitude, coordinate.Position);
        }

        throw new ArgumentException("Invalid coordinates format. Use numbers for Latitude and Longitude.");
    }
}