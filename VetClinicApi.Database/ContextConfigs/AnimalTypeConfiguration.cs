using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class AnimalTypeConfiguration : BaseConfiguration<AnimalType>
{
    public override void Configure(EntityTypeBuilder<AnimalType> builder)
    {
        builder
            .ToTable("T_AnimalType")
            .HasKey(x => x.Id);

        base.Configure(builder);
    }
}
