using System.Collections.Generic;
using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IPlacesFinder
{
    Task<IReadOnlyList<Places>> GetPlacesWithinArea(
        AreaConfiguration config,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations);
}