using DataAccessLayer.Repositories;

namespace RadiowaveDesigner.Services.Calculations;

internal class PropagationRangeCalculator : IPropagationRangeCalculator
{
    private readonly IBaseStationRepository _baseStationRepository;

    public PropagationRangeCalculator(IBaseStationRepository baseStationRepository)
    {
        _baseStationRepository = baseStationRepository;
    }

    public async Task<int?> Calculate()
    {
        var config = await _baseStationRepository.Get();
        if (config == null)
        {
            return null;
        }

        return 300;
    }
}