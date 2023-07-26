using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public interface IAbstractRepository<TEntity> where TEntity : class, IEntity
{
    TEntity Add(TEntity entity);
    void Delete(int id);
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    TEntity Update(TEntity entity);
}