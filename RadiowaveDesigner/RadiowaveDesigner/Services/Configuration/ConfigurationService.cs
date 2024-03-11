using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Configuration;

internal class ConfigurationService : IConfigurationService
{
    private readonly IBaseStationRepository _baseStationRepository;

    public ConfigurationService(
        IBaseStationRepository baseStationRepository)
    {
        _baseStationRepository = baseStationRepository;
    }

    public async Task<IEnumerable<BaseStationConfiguration?>> GetAll()
    {
        return await _baseStationRepository.GetAll();
    }

    public async Task Add(BaseStationConfiguration configuration)
    {
        await _baseStationRepository.Create(configuration);
    }

    public async Task Delete(long id)
    {
        await _baseStationRepository.Delete(id);
    }

    public async Task<BaseStationConfiguration?> GetBaseStationConfig(long id)
    {
        return await _baseStationRepository.Get(id);
    }

    public async Task UpdateFrequency(int frequency, bool existing)
    {
        await _baseStationRepository.ChangeFrequency(frequency, existing);
    }
    
}