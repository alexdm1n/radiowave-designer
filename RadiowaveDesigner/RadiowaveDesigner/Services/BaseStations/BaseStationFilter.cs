using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.BaseStations;

internal class BaseStationFilter : IBaseStationFilter
{
    public IReadOnlyList<BaseStationConfiguration> Filter(
        IReadOnlyList<BaseStationConfiguration> configs, bool showExistingBaseStations)
    {
        return showExistingBaseStations
            ? configs
            : configs.Where(c => !c.Existing).ToList();
    }
}