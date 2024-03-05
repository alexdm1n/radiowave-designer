namespace RadiowaveDesigner.Services.BaseStations.Migrations;

internal interface IBaseStationDeduplicator
{
    List<object[]> FilterStations(List<object[]> stations, double precision);
}