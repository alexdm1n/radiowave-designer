using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.ViewModels;

public class ConfigurationViewModel
{
    public BaseStationConfiguration BaseStationConfiguration { get; set; }
    
    public IEnumerable<CoordinatesConfiguration> CoordinatesConfigurations { get; set; }
}