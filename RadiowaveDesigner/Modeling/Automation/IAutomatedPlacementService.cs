using System.Collections.Generic;
using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IAutomatedPlacementService
{
    Task PlaceBaseStations(
        AreaConfiguration areaConfig,
        IReadOnlyList<Places> prioritizedPlaces,
        bool includeExistingStations);
}