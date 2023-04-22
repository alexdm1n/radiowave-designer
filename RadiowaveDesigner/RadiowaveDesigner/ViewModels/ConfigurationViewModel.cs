using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.ViewModels;

public class ConfigurationViewModel
{
    public IEnumerable<BaseStationConfiguration> BaseStationConfiguration { get; set; }
}