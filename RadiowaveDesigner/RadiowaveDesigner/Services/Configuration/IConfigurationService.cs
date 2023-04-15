using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Configuration;

public interface IConfigurationService
{
    Task UpdateBaseStationConfig(BaseStationConfiguration configuration);

    Task<BaseStationConfiguration?> GetBaseStationConfig();

    Task<IEnumerable<CoordinatesConfiguration>> GetCoordinates();

    Task AddCoordinates(string coordinates);

    Task DeleteCoordinates(long id);
}