using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class BaseStationsFinder : IBaseStationsFinder
{
    private readonly IBaseStationRepository _baseStationRepository;

    public BaseStationsFinder(IBaseStationRepository baseStationRepository)
    {
        _baseStationRepository = baseStationRepository;
    }

    public async Task<IReadOnlyList<BaseStationConfiguration>> GetBaseStationsWithinArea(
        AreaConfiguration areaConfig, bool includeExistingStations)
    {
        var baseStations = includeExistingStations
            ? (await _baseStationRepository.GetAll()).ToList()
            : (await _baseStationRepository.GetAll()).Where(bs => !bs.Existing).ToList();
        if (!baseStations.Any())
        {
            return Array.Empty<BaseStationConfiguration>();
        }
        
        var baseStationsInArea = new List<BaseStationConfiguration>();

        foreach (var baseStation in baseStations)
        {
            if (IsBaseStationInArea(baseStation, areaConfig))
            {
                baseStationsInArea.Add(baseStation);
            }
        }

        return baseStationsInArea;
    }
    
    private bool IsBaseStationInArea(BaseStationConfiguration baseStation, AreaConfiguration areaConfig)
    {
        var coordinate1 = ParseCoordinates(areaConfig.Coordinates.ElementAt(0).Coordinates);
        var coordinate2 = ParseCoordinates(areaConfig.Coordinates.ElementAt(1).Coordinates);
        var minLat = Math.Min(coordinate1.Latitude, coordinate2.Latitude);
        var maxLat = Math.Max(coordinate1.Latitude, coordinate2.Latitude);
        var minLon = Math.Min(coordinate1.Longitude, coordinate2.Longitude);
        var maxLon = Math.Max(coordinate1.Longitude, coordinate2.Longitude);

        var baseStationCoord = ParseCoordinates(baseStation.Coordinates);
        var stationLat = baseStationCoord.Latitude;
        var stationLon = baseStationCoord.Longitude;

        return stationLat >= minLat && stationLat <= maxLat && stationLon >= minLon && stationLon <= maxLon;
    }
    
    private (double Latitude, double Longitude) ParseCoordinates(string coordinates)
    {
        var parts = coordinates.Split(',');
        if (parts.Length != 2 || !double.TryParse(parts[0], CultureInfo.InvariantCulture, out var latitude) ||
            !double.TryParse(parts[1], CultureInfo.InvariantCulture, out var longitude))
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        return (latitude, longitude);
    }
}