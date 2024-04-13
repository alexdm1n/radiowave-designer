using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using RadiowaveDesigner.Modeling.Automation.Constants;
using RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class BaseStationsAutomatedCreator : IBaseStationsAutomatedCreator
{
    private readonly IBaseStationsFinder _baseStationsFinder;
    private readonly ISuiModelCalculator _suiModelCalculator;
    private readonly IBaseStationRepository _baseStationRepository;
    private readonly IAutomatedBaseStationsFilter _automatedBaseStationsFilter;

    public BaseStationsAutomatedCreator(
        IBaseStationsFinder baseStationsFinder,
        ISuiModelCalculator suiModelCalculator,
        IBaseStationRepository baseStationRepository,
        IAutomatedBaseStationsFilter automatedBaseStationsFilter)
    {
        _baseStationsFinder = baseStationsFinder;
        _suiModelCalculator = suiModelCalculator;
        _baseStationRepository = baseStationRepository;
        _automatedBaseStationsFilter = automatedBaseStationsFilter;
    }

    public async Task PlaceBaseStations(bool includeExistingStations, AreaConfiguration areaConfig)
    {
        var currentBaseStations = await _baseStationsFinder
            .GetBaseStationsWithinArea(areaConfig, includeExistingStations);
        var basePropagationRange = CalculateBasePropagationRange();
        var topLeftCoord =
            ParseCoordinates(areaConfig.Coordinates.Single(coord => coord.Position == 1).Coordinates);
        var bottomRightCoord =
            ParseCoordinates(areaConfig.Coordinates.Single(coord => coord.Position == 2).Coordinates);
        var minLatitude = Math.Min(topLeftCoord.Latitude, bottomRightCoord.Latitude);
        var maxLatitude = Math.Max(topLeftCoord.Latitude, topLeftCoord.Latitude);
        var minLongitude = Math.Min(topLeftCoord.Longitude, bottomRightCoord.Longitude);
        var maxLongitude = Math.Max(topLeftCoord.Longitude, bottomRightCoord.Longitude);
        var calculatedCoordinates = GenerateCoordinates(
            basePropagationRange, minLatitude, maxLatitude, minLongitude, maxLongitude, currentBaseStations);
        await UpsertAutomatedStations(calculatedCoordinates);
    }

    public IReadOnlyList<string> GenerateCoordinates(
        int basePropagationRange,
        double minLatitude,
        double maxLatitude,
        double minLongitude,
        double maxLongitude,
        IReadOnlyList<BaseStationConfiguration> baseStations)
    {
        double metersPerDegreeLatitude = 111000;
        double metersPerDegreeLongitude = 111000 * Math.Cos((minLatitude + maxLatitude) / 2 * Math.PI / 180.0);
        double degreesLatitude = basePropagationRange / metersPerDegreeLatitude;
        double degreesLongitude = basePropagationRange / metersPerDegreeLongitude;

        var calculatedCoords = new List<string>();

        double degreesLongitudeOffset = basePropagationRange / (2 * metersPerDegreeLongitude);
        double degreesLatitudeOffset = basePropagationRange / (2 * metersPerDegreeLatitude);

        bool startFromLeft = true;
        double lat = minLatitude;

        while (lat <= maxLatitude + degreesLatitudeOffset)
        {
            double lon = startFromLeft ? minLongitude : minLongitude + degreesLongitudeOffset;

            while (lon <= maxLongitude + degreesLongitudeOffset)
            {
                string coordinates = $"{lat},{lon}";
                calculatedCoords.Add(coordinates);

                lon += degreesLongitude * 1.6;
            }

            lat += degreesLatitude * 1.6;
            startFromLeft = !startFromLeft;
        }

        return _automatedBaseStationsFilter.DeduplicateWithExisting(baseStations, calculatedCoords);
    }

    private async Task UpsertAutomatedStations(IReadOnlyList<string> coordinates)
    {
        var automatedBaseStations = coordinates.Select(c => new BaseStationConfiguration
        {
            Automated = true,
            Existing = false,
            FrequencyInMHz = AutomatedBaseStationsConstants.FrequencyInMHz,
            Height = AutomatedBaseStationsConstants.Height,
            Coordinates = c,
        });

        await _baseStationRepository.UpsertList(automatedBaseStations);
    }

    private int CalculateBasePropagationRange()
    {
        var defaultBaseStationConfig = new BaseStationConfiguration
        {
            FrequencyInMHz = AutomatedBaseStationsConstants.FrequencyInMHz,
            Height = AutomatedBaseStationsConstants.Height,
        };

        return _suiModelCalculator.CalculatePropagationRange(defaultBaseStationConfig);
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