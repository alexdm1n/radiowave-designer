using System.Collections.Generic;
using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IPrioritizedPlacesBaseStationCreator
{
    Task PlaceBaseStations(IReadOnlyList<Places> prioritizedPlaces);
}