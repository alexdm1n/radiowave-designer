namespace RadiowaveDesigner.Services.AreaConfiguration;

public interface IAreaConfigurationService
{
    Task<IEnumerable<Models.Models.AreaConfiguration?>> GetAll();

    Task Upsert(string coordinatesString);
}