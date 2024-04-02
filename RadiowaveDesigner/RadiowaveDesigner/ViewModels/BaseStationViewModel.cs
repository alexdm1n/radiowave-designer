using RadiowaveDesigner.Models;

namespace RadiowaveDesigner.ViewModels;

public class BaseStationViewModel
{
    public int? PropagationRange { get; set; }
    
    public CoordinatesModel? Coordinates { get; set; }
    
    public bool Existing { get; set; }
    
    public bool Automated { get; set; }
}