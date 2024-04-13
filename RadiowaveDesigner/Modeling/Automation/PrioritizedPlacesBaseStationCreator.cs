using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using RadiowaveDesigner.Modeling.Automation.Constants;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class PrioritizedPlacesBaseStationCreator : IPrioritizedPlacesBaseStationCreator
{
    private readonly IBaseStationRepository _baseStationRepository;

    public PrioritizedPlacesBaseStationCreator(IBaseStationRepository baseStationRepository)
    {
        _baseStationRepository = baseStationRepository;
    }

    public async Task PlaceBaseStations(IReadOnlyList<Places> prioritizedPlaces)
    {
        foreach (var place in prioritizedPlaces)
        {
            var coordinates = ParseCoordinates(place.Coordinates);
            var baseStationConfig = new BaseStationConfiguration
            {
                Automated = true,
                Existing = false,
                Height = AutomatedBaseStationsConstants.Height,
                FrequencyInMHz = AutomatedBaseStationsConstants.FrequencyInMHz,
                Coordinates = $"{coordinates.Latitude},{coordinates.Longitude}",
            };

            await _baseStationRepository.Create(baseStationConfig);
        }
    }
    
    private (double Latitude, double Longitude) ParseCoordinates(string coordinates)
    {
        var parts = coordinates.Split(',');
        if (parts.Length != 2 || !double.TryParse(parts[0], CultureInfo.InvariantCulture, out var longitude) ||
            !double.TryParse(parts[1], CultureInfo.InvariantCulture, out var latitude))
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        return (latitude, longitude);
    }
}