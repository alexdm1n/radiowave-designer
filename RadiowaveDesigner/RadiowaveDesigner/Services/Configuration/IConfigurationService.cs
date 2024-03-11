using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Configuration;

public interface IConfigurationService
{
    Task Add(BaseStationConfiguration configuration);

    Task<BaseStationConfiguration?> GetBaseStationConfig(long id);

    Task<IEnumerable<BaseStationConfiguration?>> GetAll();

    Task Delete(long id);

    Task UpdateFrequency(int frequency, bool existing);
}