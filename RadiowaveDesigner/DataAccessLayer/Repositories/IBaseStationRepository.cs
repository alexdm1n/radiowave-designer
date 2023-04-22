﻿using RadiowaveDesigner.Models.Models;

namespace DataAccessLayer.Repositories;

public interface IBaseStationRepository
{
    Task<BaseStationConfiguration?> Get(long id);

    Task Create(BaseStationConfiguration configuration);

    Task Delete(long id);

    Task<IEnumerable<BaseStationConfiguration?>> GetAll();
}