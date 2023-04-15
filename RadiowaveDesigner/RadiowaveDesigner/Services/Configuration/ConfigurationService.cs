using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Configuration;

internal class ConfigurationService : IConfigurationService
{
    private readonly IBaseStationRepository _baseStationRepository;
    private readonly ICoordinatesRepository _coordinatesRepository;

    public ConfigurationService(
        IBaseStationRepository baseStationRepository,
        ICoordinatesRepository coordinatesRepository)
    {
        _baseStationRepository = baseStationRepository;
        _coordinatesRepository = coordinatesRepository;
    }

    public async Task UpdateBaseStationConfig(BaseStationConfiguration configuration)
    {
        var currentConfig = await GetBaseStationConfig();
        if (currentConfig == null)
        {
            await _baseStationRepository.Create(configuration);
            return;
        }

        currentConfig.Height = configuration.Height;
        currentConfig.FrequencyInHz = configuration.FrequencyInHz;

        await _baseStationRepository.Update(currentConfig);
    }

    public async Task AddCoordinates(string coordinates)
    {
        var coordsConfig = new CoordinatesConfiguration()
        {
            Value = coordinates,
        };
        await _coordinatesRepository.Add(coordsConfig);
    }
    public async Task<IEnumerable<CoordinatesConfiguration>> GetCoordinates()
    {
        return await _coordinatesRepository.GetAll();
    }

    public async Task DeleteCoordinates(long id)
    {
        await _coordinatesRepository.Delete(id);
    }

    public async Task<BaseStationConfiguration?> GetBaseStationConfig()
    {
        return await _baseStationRepository.Get();
    }
}