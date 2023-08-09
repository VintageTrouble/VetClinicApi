using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Extensions;

namespace VetClinicApi.Database.ContextConfigs.Abstract;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var dateTimes = typeof(TEntity)
            .GetProperties()
            .Where(x => x.PropertyType == typeof(DateTime));

        foreach (var item in dateTimes)
        {
            builder
                .Property<DateTime>(item.Name)
                    .HasConversion(
                        src => src.ToUnspecifiedKind(),
                        dst => dst.ToUnspecifiedKind());
        }
    }
}
