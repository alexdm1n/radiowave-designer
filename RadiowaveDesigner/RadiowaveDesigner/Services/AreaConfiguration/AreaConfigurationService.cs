using DataAccessLayer.Repositories;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.AreaConfiguration;

internal class AreaConfigurationService : IAreaConfigurationService
{
    private readonly IAreaRepository _areaRepository;

    public AreaConfigurationService(IAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<IEnumerable<Models.Models.AreaConfiguration?>> GetAll()
    {
        return await _areaRepository.GetAll();
    }

    public async Task Upsert(string coordinatesString)
    {
        await _areaRepository.DeleteAll();
        var config = BuildAreaConfig(coordinatesString);
        await _areaRepository.Upsert(config);
    }

    private Models.Models.AreaConfiguration BuildAreaConfig(string coordinatesString)
    {
        var coordinates = coordinatesString.Split(';');
        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Use 2 coordinates in order to setup Area Configuration");
        }

        var areaConfig = new Models.Models.AreaConfiguration();
        int position = 1;
        var coords = new List<Coordinate>();
        foreach (var coord in coordinates)
        {
            coords.Add(new Coordinate
            {
                Coordinates = coord,
                Position = position,
            });
            position++;
        }

        areaConfig.Coordinates = coords;
        return areaConfig;
    }
}