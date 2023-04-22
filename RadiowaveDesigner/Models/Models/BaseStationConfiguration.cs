namespace RadiowaveDesigner.Models.Models;

public class BaseStationConfiguration
{
    public long Id { get; set; }

    public int FrequencyInHz { get; set; }
    
    public int Height { get; set; }
    
    public string Coordinates { get; set; }
}