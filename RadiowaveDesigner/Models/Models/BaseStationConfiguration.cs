namespace RadiowaveDesigner.Models.Models;

public class BaseStationConfiguration
{
    public long Id { get; set; }

    public int FrequencyInMHz { get; set; }
    
    public int Height { get; set; }
    
    public string Coordinates { get; set; }
    
    public bool Existing { get; set; }
}