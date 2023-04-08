using DataAccessLayer.Context;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public class CoordinatesRepository : BaseRepository<CoordinatesConfiguration>
{
    public CoordinatesRepository(AppDbContext context) : base(context)
    {
    }

    public override CoordinatesConfiguration Get(long entityId)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<CoordinatesConfiguration> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Update(CoordinatesConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Create(CoordinatesConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(CoordinatesConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long id)
    {
        throw new NotImplementedException();
    }
}