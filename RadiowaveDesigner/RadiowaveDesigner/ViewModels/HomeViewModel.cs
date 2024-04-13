namespace RadiowaveDesigner.ViewModels;

public class HomeViewModel
{
    public string ApiKey { get; set; }

    public string  BaseStationViewModelsJson { get; set; }
    
    public string AreaCoordinatesViewModelJson { get; set; }
    
    public bool ShowExistingBaseStations { get; set; }
    
    public bool HasAutomatedStations { get; set; }
    
    public bool HasAreaConfig { get; set; }
}