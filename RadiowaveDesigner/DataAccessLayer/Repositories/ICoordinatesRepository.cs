using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface ICoordinatesRepository
{
    Task<IEnumerable<CoordinatesConfiguration>> GetAll();

    Task Add(CoordinatesConfiguration coordinatesConfiguration);

    Task Delete(long id);
}