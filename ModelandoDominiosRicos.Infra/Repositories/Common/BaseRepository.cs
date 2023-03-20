using System;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories.Common;

namespace ModelandoDominiosRicos.Infra.Repositories.Common;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : Entity
    where TKey : struct
{
    private readonly DbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public async Task<TEntity> GetById(TKey id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public async Task Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public async Task Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }
}

