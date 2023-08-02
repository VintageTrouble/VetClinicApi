using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public abstract class AbstractRepository<TEntity> : IAbstractRepository<TEntity> where TEntity : class, IEntity
{
    protected IDbContextFactory<VetClinicContext> _contextFactory;
    public AbstractRepository(IDbContextFactory<VetClinicContext> contextFactory) => _contextFactory = contextFactory;

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Set<TEntity>().ToListAsync();
    }
    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Set<TEntity>().Where(filter).ToListAsync();
    }
    public virtual async Task<TEntity?> GetById(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.FindAsync<TEntity>(id);
    }
    public virtual async Task<TEntity> Add(TEntity entity)
    {
        using var context = _contextFactory.CreateDbContext();
        var result = await context.Set<TEntity>().AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }
    public virtual async Task<TEntity> Update(TEntity entity)
    {
        using var context = _contextFactory.CreateDbContext();

        if (await context.FindAsync<TEntity>(entity.Id) is null)
            throw new ArgumentOutOfRangeException(nameof(entity.Id));

        var result = context.Update(entity);
        context.SaveChangesAsync();

        return result.Entity;
    }
    public virtual async Task Delete(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        if (await context.FindAsync<TEntity>(id) is not TEntity entity)
            throw new ArgumentOutOfRangeException(nameof(id));

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }
}
