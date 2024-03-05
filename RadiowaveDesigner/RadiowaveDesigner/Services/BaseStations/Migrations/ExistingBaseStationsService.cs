using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.BaseStations.Migrations;

internal class ExistingBaseStationsService : IExistingBaseStationsService
{
    private readonly IBaseStationRepository _baseStationRepository;
    private readonly IBaseStationDeduplicator _baseStationDeduplicator;

    public ExistingBaseStationsService(
        IBaseStationRepository baseStationRepository,
        IBaseStationDeduplicator baseStationDeduplicator)
    {
        _baseStationRepository = baseStationRepository;
        _baseStationDeduplicator = baseStationDeduplicator;
    }

    public async Task AddExistingBaseStations(List<object[]> existingBaseStations)
    {
        var filteredStations = _baseStationDeduplicator.FilterStations(existingBaseStations, 30);

        var baseStationConfigs = filteredStations.Select(bs => new BaseStationConfiguration
        {
            FrequencyInMHz = 5000,
            Height = GetHeightValue(bs[7]),
            Coordinates = CreateCoordinates(bs[6], bs[5]),
            Existing = true,
        });

        await _baseStationRepository.UpsertList(baseStationConfigs);
    }

    private static string CreateCoordinates(object latitude, object longitude)
    {
        var stringLatitude = latitude.ToString()!.Remove(latitude.ToString()!.Length - 1, 1);
        var stringLongitude = longitude.ToString()!.Remove(longitude.ToString()!.Length - 1, 1);
        return string.Join(",", stringLatitude, stringLongitude);
    }

    private static int GetHeightValue(object height)
    {
        var datasetHeight = (int) Math.Round(Convert.ToDouble(height));
        return datasetHeight < 20 ? 20 : datasetHeight;
    }
}