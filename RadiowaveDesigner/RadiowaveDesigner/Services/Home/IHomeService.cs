using RadiowaveDesigner.Models;

namespace RadiowaveDesigner.Services.Home;

internal interface IHomeService
{
    Task<IEnumerable<CoordinatesModel>?> GetCoordinates();
}