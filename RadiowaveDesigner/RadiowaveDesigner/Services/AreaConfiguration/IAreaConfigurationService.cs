namespace RadiowaveDesigner.Services.AreaConfiguration;

public interface IAreaConfigurationService
{
    Task<Models.Models.AreaConfiguration?> Get();

    Task Upsert(string coordinatesString);
}