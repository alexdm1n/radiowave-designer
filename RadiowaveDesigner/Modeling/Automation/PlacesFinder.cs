using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using RadiowaveDesigner.Modeling.Automation.Constants;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class PlacesFinder : IPlacesFinder
{
    private readonly IPlacesRepository _placesRepository;
    private readonly IPlacesDeduplicator _placesDeduplicator;

    public PlacesFinder(IPlacesRepository placesRepository, IPlacesDeduplicator placesDeduplicator)
    {
        _placesRepository = placesRepository;
        _placesDeduplicator = placesDeduplicator;
    }

    public async Task<IReadOnlyList<Places>> GetPlacesWithinArea(
        AreaConfiguration config,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations)
    {
        var places = (await _placesRepository.GetAll()).ToList();
        if (!places.Any())
        {
            return Array.Empty<Places>();
        }
        
        var placesWithinArea = new List<Places>();

        foreach (var place in places)
        {
            if (IsPlaceInArea(place, config))
            {
                placesWithinArea.Add(place);
            }
        }

        return _placesDeduplicator
            .Deduplicate(placesWithinArea, existingBaseStations, DeduplicationConstants.DefaultPrecision);
    }
    
    private bool IsPlaceInArea(Places place, AreaConfiguration areaConfig)
    {
        var coordinate1 = ParseCoordinates(areaConfig.Coordinates.ElementAt(0).Coordinates);
        var coordinate2 = ParseCoordinates(areaConfig.Coordinates.ElementAt(1).Coordinates);
        var minLon = Math.Min(coordinate1.Latitude, coordinate2.Latitude);
        var maxLon = Math.Max(coordinate1.Latitude, coordinate2.Latitude);
        var minLat = Math.Min(coordinate1.Longitude, coordinate2.Longitude);
        var maxLat = Math.Max(coordinate1.Longitude, coordinate2.Longitude);

        var placeCoord = ParseCoordinates(place.Coordinates);
        var placeLat = placeCoord.Latitude;
        var placeLon = placeCoord.Longitude;

        return placeLat >= minLat && placeLat <= maxLat && placeLon >= minLon && placeLon <= maxLon;
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