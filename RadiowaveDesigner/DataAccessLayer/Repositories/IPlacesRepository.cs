using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface IPlacesRepository
{
    Task<bool> Exist(string region);

    Task<IEnumerable<Places?>> GetAll();

    Task<IEnumerable<Places>> GetByCategory(Category category);

    Task Upsert(IList<Places> places);
}