using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.BaseStations;

internal interface IBaseStationFilter
{
    IReadOnlyList<BaseStationConfiguration> Filter(
        IReadOnlyList<BaseStationConfiguration> configs, bool showExistingBaseStations);
}