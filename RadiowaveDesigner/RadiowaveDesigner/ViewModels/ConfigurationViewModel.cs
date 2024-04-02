using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.ViewModels;

public class ConfigurationViewModel
{
    public IEnumerable<BaseStationConfiguration> BaseStationConfiguration { get; set; }
    
    public AreaConfiguration AreaConfiguration { get; set; }
    
    public bool ShowExistingBaseStations { get; set; }
}