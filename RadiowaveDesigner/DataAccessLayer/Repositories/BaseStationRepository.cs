using DataAccessLayer.Context;
using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public class BaseStationRepository : BaseRepository<BaseStationConfiguration>
{
    public BaseStationRepository(AppDbContext context) : base(context)
    {
    }

    public override BaseStationConfiguration Get(long entityId)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<BaseStationConfiguration> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Update(BaseStationConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Create(BaseStationConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(BaseStationConfiguration entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long id)
    {
        throw new NotImplementedException();
    }
}