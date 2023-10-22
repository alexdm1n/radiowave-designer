using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface IAreaRepository
{
    Task<IEnumerable<AreaConfiguration?>> GetAll();

    Task Upsert(AreaConfiguration configurations);

    Task DeleteAll();
}