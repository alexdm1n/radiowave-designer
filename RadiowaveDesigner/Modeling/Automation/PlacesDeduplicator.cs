using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class PlacesDeduplicator : IPlacesDeduplicator
{
    public IReadOnlyList<Places> Deduplicate(
        IReadOnlyList<Places> places,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        int precision)
    {
        var deduplicationResult = new List<Places>();
        foreach (var place in places)
        {
            if (!IsCloseToExistingPlace(place, deduplicationResult, precision) &&
                !IsCloseToExistingStations(place, existingBaseStations, precision))
            {
                deduplicationResult.Add(place);
            }
        }

        return deduplicationResult;
    }

    private bool IsCloseToExistingStations(
        Places place,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        int precision)
    {
        foreach (var existingBaseStation in existingBaseStations)
        {
            var existingBaseStationCoord = ParseBaseStationCoordinates(existingBaseStation.Coordinates);
            double latitude1 = existingBaseStationCoord.Latitude;
            double longitude1 = existingBaseStationCoord.Longitude;
            var placeCoord = ParsePlacesCoordinates(place.Coordinates);
            double latitude2 = placeCoord.Latitude;
            double longitude2 = placeCoord.Longitude;

            if (DistanceBetweenCoordinates(latitude1, longitude1, latitude2, longitude2) <= precision)
            {
                return true;
            }
        }
        
        return false;
    }

    private bool IsCloseToExistingPlace(Places place, List<Places> existingPlaces, double precision)
    {
        foreach (var existingPlace in existingPlaces)
        {
            var existingCoord = ParsePlacesCoordinates(existingPlace.Coordinates);
            double latitude1 = existingCoord.Latitude;
            double longitude1 = existingCoord.Longitude;
            var placeCoord = ParsePlacesCoordinates(place.Coordinates);
            double latitude2 = placeCoord.Latitude;
            double longitude2 = placeCoord.Longitude;

            if (DistanceBetweenCoordinates(latitude1, longitude1, latitude2, longitude2) <= precision)
            {
                return true;
            }
        }

        return false;
    }
    
    private (double Latitude, double Longitude) ParsePlacesCoordinates(string coordinates)
    {
        var parts = coordinates.Split(',');
        if (parts.Length != 2 || !double.TryParse(parts[0], CultureInfo.InvariantCulture, out var longitude) ||
            !double.TryParse(parts[1], CultureInfo.InvariantCulture, out var latitude))
        {
            throw new ArgumentException("Invalid coordinates format. Use 'Latitude, Longitude' format.");
        }

        return (latitude, longitude);
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