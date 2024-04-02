using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface IAreaRepository
{
    Task<AreaConfiguration?> Get();

    Task Upsert(AreaConfiguration configurations);

    Task DeleteAll();
}