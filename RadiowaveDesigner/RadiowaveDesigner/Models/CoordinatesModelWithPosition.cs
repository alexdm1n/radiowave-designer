namespace RadiowaveDesigner.Models;

internal class CoordinatesModelWithPosition
{
    public CoordinatesModelWithPosition(double latitude, double longitude, int position)
    {
        Latitude = latitude;
        Longitude = longitude;
        Position = position;
    }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public int Position { get; set; }
}