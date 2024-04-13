using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;

namespace RadiowaveDesigner.Modeling.Automation;

internal class BaseStationsAutomationService : IBaseStationsAutomationService
{
    private readonly IAreaRepository _areaRepository;
    private readonly IBaseStationsFinder _baseStationsFinder;
    private readonly IPlacesFinder _placesFinder;
    private readonly IAutomatedPlacementService _automatedPlacementService;
    private readonly IBaseStationRepository _baseStationRepository;
    private readonly IUserConfigurationRepository _userConfigurationRepository;

    public BaseStationsAutomationService(
        IAreaRepository areaRepository,
        IBaseStationsFinder baseStationsFinder,
        IPlacesFinder placesFinder,
        IAutomatedPlacementService automatedPlacementService,
        IBaseStationRepository baseStationRepository,
        IUserConfigurationRepository userConfigurationRepository)
    {
        _areaRepository = areaRepository;
        _baseStationsFinder = baseStationsFinder;
        _placesFinder = placesFinder;
        _automatedPlacementService = automatedPlacementService;
        _baseStationRepository = baseStationRepository;
        _userConfigurationRepository = userConfigurationRepository;
    }

    public async Task ProcessAutomatedPlacement()
    {
        var areaConfig = await _areaRepository.Get();
        var includeExistingStations = await _userConfigurationRepository.ShowExistingBaseStations();
        var baseStationsWithinArea = await _baseStationsFinder.GetBaseStationsWithinArea(areaConfig, includeExistingStations);
        var placesWithinArea = await _placesFinder.GetPlacesWithinArea(areaConfig, baseStationsWithinArea);
        await _automatedPlacementService.PlaceBaseStations(areaConfig, placesWithinArea, includeExistingStations);
    }

    public async Task RestoreAutomatedPlacement()
    {
        var automatedStations = (await _baseStationRepository.GetAll()).Where(s => s.Automated).ToList();
        await _baseStationRepository.DeleteList(automatedStations);
    }
}