namespace RadiowaveDesigner.Services.BaseStations.Migrations;

public interface IExistingBaseStationsService
{
    Task AddExistingBaseStations(List<object[]> existingBaseStations);
}