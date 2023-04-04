namespace RadiowaveDesigner.Models;

public class CoordinatesModel
{
    public CoordinatesModel(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}