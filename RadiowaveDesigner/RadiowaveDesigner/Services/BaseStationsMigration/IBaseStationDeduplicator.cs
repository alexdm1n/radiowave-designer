namespace RadiowaveDesigner.Services.BaseStationsMigration;

internal interface IBaseStationDeduplicator
{
    List<object[]> FilterStations(List<object[]> stations, double precision);
}