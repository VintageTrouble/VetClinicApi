using System.Linq.Expressions;
using VetClinicApi.Core.Entities.Interfaces;

namespace VetClinicApi.Database.Repositories;

public interface IAbstractRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> Add(TEntity entity);
    Task Delete(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> GetById(int id);
    Task<TEntity> Update(TEntity entity);
}