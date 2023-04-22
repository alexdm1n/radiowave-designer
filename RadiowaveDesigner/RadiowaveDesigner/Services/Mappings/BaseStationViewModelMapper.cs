using RadiowaveDesigner.Models;
using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.Services.Calculations;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Mappings;

internal class BaseStationViewModelMapper : IBaseStationViewModelMapper
{
    private readonly IPropagationRangeCalculator _propagationRangeCalculator;

    public BaseStationViewModelMapper(IPropagationRangeCalculator propagationRangeCalculator)
    {
        _propagationRangeCalculator = propagationRangeCalculator;
    }

    public BaseStationViewModel Map(BaseStationConfiguration config)
    {
        return new()
        {
            Coordinates = config.Coordinates == null ? null : SplitToModel(config.Coordinates),
            PropagationRange = _propagationRangeCalculator.Calculate(config),
        };
    }

    private static CoordinatesModel? SplitToModel(string coordinates)
    {
        var parts = coordinates.Split(',');

        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        if (double.TryParse(parts[0], out var latitude) && double.TryParse(parts[1], out var longitude))
        {
            return new CoordinatesModel (latitude, longitude);
        }

        throw new ArgumentException("Invalid coordinates format. Use numbers for Latitude and Longitude.");
    }
}