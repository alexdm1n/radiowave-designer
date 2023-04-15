using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface IBaseStationRepository
{
    Task<BaseStationConfiguration?> Get();

    Task Update(BaseStationConfiguration configuration);

    Task Create(BaseStationConfiguration configuration);
}