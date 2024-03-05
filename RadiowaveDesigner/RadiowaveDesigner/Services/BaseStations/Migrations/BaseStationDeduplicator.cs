using System.Device.Location;

namespace RadiowaveDesigner.Services.BaseStations.Migrations;

internal class BaseStationDeduplicator : IBaseStationDeduplicator
{
    public List<object[]> FilterStations(List<object[]> stations, double precision)
    {
        List<object[]> filteredStations = new List<object[]>();

        foreach (var station in stations)
        {
            if (!IsCloseToExisting(station, filteredStations, precision))
            {
                filteredStations.Add(station);
            }
        }

        return filteredStations;
    }

    private static bool IsCloseToExisting(object[] station, List<object[]> existingStations, double precision)
    {
        foreach (var existingStation in existingStations)
        {
            double latitude1 = GetCoordinateValue(station[6]);
            double longitude1 = GetCoordinateValue(station[5]);
            double latitude2 = GetCoordinateValue(existingStation[6]);
            double longitude2 = GetCoordinateValue(existingStation[5]);

            if (DistanceBetweenCoordinates(latitude1, longitude1, latitude2, longitude2) <= precision)
            {
                return true;
            }
        }

        return false;
    }

    private static double DistanceBetweenCoordinates(double lat1, double lon1, double lat2, double lon2)
    {
        var coordinate1 = new GeoCoordinate(lat1, lon1);
        var coordinate2 = new GeoCoordinate(lat2, lon2);
        var distance = coordinate1.GetDistanceTo(coordinate2);
        return distance;
    }

    private static double GetCoordinateValue(object coordinate)
    {
        var stringCoordinate = coordinate.ToString();
        return Convert.ToDouble(stringCoordinate!.Remove(stringCoordinate.Length - 1, 1));
    }
}