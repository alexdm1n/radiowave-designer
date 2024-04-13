using System.Collections.Generic;
using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IBaseStationsFinder
{
    Task<IReadOnlyList<BaseStationConfiguration>> GetBaseStationsWithinArea(
        AreaConfiguration areaConfig, bool includeExistingStations);
}