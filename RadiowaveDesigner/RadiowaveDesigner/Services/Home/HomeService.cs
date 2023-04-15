using RadiowaveDesigner.Models;
using RadiowaveDesigner.Services.Configuration;

namespace RadiowaveDesigner.Services.Home;

internal class HomeService : IHomeService
{
    private readonly IConfigurationService _configurationService;

    public HomeService(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    public async Task<IEnumerable<CoordinatesModel>?> GetCoordinates()
    {
        var coordinates = (await _configurationService.GetCoordinates()).ToList();
        if (!coordinates.Any())
        {
            return null;
        }

        var coordinatesList = new List<CoordinatesModel>();
        foreach (var coord in coordinates)
        {
            coordinatesList.Add(SplitToModel(coord.Value));
        }

        return coordinatesList;
    }

    private static CoordinatesModel SplitToModel(string coordinates)
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