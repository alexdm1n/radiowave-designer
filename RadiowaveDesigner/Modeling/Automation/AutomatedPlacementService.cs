using System.Collections.Generic;
using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal class AutomatedPlacementService : IAutomatedPlacementService
{
    private readonly IPrioritizedPlacesBaseStationCreator _prioritizedPlacesBaseStationCreator;
    private readonly IBaseStationsAutomatedCreator _baseStationsAutomatedCreator;

    public AutomatedPlacementService(
        IPrioritizedPlacesBaseStationCreator prioritizedPlacesBaseStationCreator,
        IBaseStationsAutomatedCreator baseStationsAutomatedCreator)
    {
        _prioritizedPlacesBaseStationCreator = prioritizedPlacesBaseStationCreator;
        _baseStationsAutomatedCreator = baseStationsAutomatedCreator;
    }

    public async Task PlaceBaseStations(
        AreaConfiguration areaConfig,
        IReadOnlyList<Places> prioritizedPlaces,
        bool includeExistingStations)
    {
        await _prioritizedPlacesBaseStationCreator.PlaceBaseStations(prioritizedPlaces);
        await _baseStationsAutomatedCreator.PlaceBaseStations(includeExistingStations, areaConfig);
    }
}