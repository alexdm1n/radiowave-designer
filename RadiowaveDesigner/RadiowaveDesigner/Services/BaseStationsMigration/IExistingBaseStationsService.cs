namespace RadiowaveDesigner.Services.BaseStationsMigration;

public interface IExistingBaseStationsService
{
    Task AddExistingBaseStations(List<object[]> existingBaseStations);
}