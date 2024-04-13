using System.Collections.Generic;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IAutomatedBaseStationsFilter
{
    IReadOnlyList<string> DeduplicateWithExisting(
        IReadOnlyList<BaseStationConfiguration> existingBaseStations,
        IReadOnlyList<string> coordinates);
}