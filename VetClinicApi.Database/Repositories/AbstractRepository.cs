using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories
{
    public abstract class AbstractRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected IDbContextFactory<VetClinicContext> _contextFactory;
        public AbstractRepository(IDbContextFactory<VetClinicContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().ToList();
            }

        }
        public virtual TEntity? GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Find<TEntity>(id);
            }

        }
        public virtual TEntity Add(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var result = context.Set<TEntity>().Add(entity);
                context.SaveChanges();

                return result.Entity;
            }
        }
        public virtual TEntity Update(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Find<TEntity>(entity.Id) is null)
                {
                    throw new ArgumentOutOfRangeException(nameof(entity.Id));
                }
                var result = context.Update(entity);
                context.SaveChanges();
                return result.Entity;
            }
        }
        public virtual void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = context.Find<TEntity>(id);
                if (entity is null)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
