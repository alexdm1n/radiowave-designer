using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.ViewModels;

public class ConfigurationViewModel
{
    public IEnumerable<BaseStationConfiguration> BaseStationConfiguration { get; set; }
    
    public IEnumerable<AreaConfiguration> AreaConfigurations { get; set; }
    
    public bool ShowExistingBaseStations { get; set; }
}