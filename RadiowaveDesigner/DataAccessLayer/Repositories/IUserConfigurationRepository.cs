namespace DataAccessLayer.Repositories;

public interface IUserConfigurationRepository
{
    Task<bool> ShowExistingBaseStations();

    Task ChangeShowExistingBaseStationsStatus();
}