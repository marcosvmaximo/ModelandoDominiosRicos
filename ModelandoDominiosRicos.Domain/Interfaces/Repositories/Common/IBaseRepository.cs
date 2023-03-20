using System;
using ModelandoDominiosRicos.Domain.Entities.Common;

namespace ModelandoDominiosRicos.Domain.Interfaces.Repositories.Common;

public interface IBaseRepository<TEntity, TKey>
    where TEntity : Entity
    where TKey : struct
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TKey id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}

