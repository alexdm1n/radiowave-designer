using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using RadiowaveDesigner.Modeling.Automation.Constants;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class AutomatedBaseStationsFilter : IAutomatedBaseStationsFilter
{
    public IReadOnlyList<string> DeduplicateWithExisting(
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        IReadOnlyList<string> coordinates)
    {
        var filteredCoordinates = new List<string>();

        if (!existingBaseStations.Any())
        {
            return coordinates;
        }

        foreach (var coordinate in coordinates)
        {
            if (!IsCloseToExistingStations(coordinate, existingBaseStations, DeduplicationConstants.DefaultPrecision))
            {
                filteredCoordinates.Add(coordinate);
            }
        }

        return filteredCoordinates;
    }
    
    private bool IsCloseToExistingStations(
        string coordinate,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        int precision)
    {
        foreach (var existingBaseStation in existingBaseStations)
        {
            var existingBaseStationCoord = ParseBaseStationCoordinates(existingBaseStation.Coordinates);
            double latitude1 = existingBaseStationCoord.Latitude;
            double longitude1 = existingBaseStationCoord.Longitude;
            var newCoordinate = ParseBaseStationCoordinates(coordinate);
            double latitude2 = newCoordinate.Latitude;
            double longitude2 = newCoordinate.Longitude;

            if (DistanceBetweenCoordinates(latitude1, longitude1, latitude2, longitude2) <= precision)
            {
                return true;
            }
        }
        
        return false;
    }
    
    private (double Latitude, double Longitude) ParseBaseStationCoordinates(string coordinates)
    {
        var parts = coordinates.Split(',');
        if (parts.Length != 2 || !double.TryParse(parts[0], CultureInfo.InvariantCulture, out var latitude) ||
            !double.TryParse(parts[1], CultureInfo.InvariantCulture, out var longitude))
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        return (latitude, longitude);
    }

    private static double DistanceBetweenCoordinates(double lat1, double lon1, double lat2, double lon2)
    {
        var coordinate1 = new GeoCoordinate(lat1, lon1);
        var coordinate2 = new GeoCoordinate(lat2, lon2);
        var distance = coordinate1.GetDistanceTo(coordinate2);
        return distance;
    }
}