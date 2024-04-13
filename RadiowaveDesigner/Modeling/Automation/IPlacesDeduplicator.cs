using System.Collections.Generic;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IPlacesDeduplicator
{
    IReadOnlyList<Places> Deduplicate(
        IReadOnlyList<Places> places,
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        int precision);
}