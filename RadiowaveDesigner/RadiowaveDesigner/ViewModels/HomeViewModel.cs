using RadiowaveDesigner.Models;

namespace RadiowaveDesigner.ViewModels;

public class HomeViewModel
{
    public string ApiKey { get; set; }

    public string CoordinatesJson { get; set; }
    
    public int PropagationRange { get; set; }
}