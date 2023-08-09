using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class AnimalConfiguration : BaseConfiguration<Animal>
{
    public override void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder
            .ToTable("T_Animal")
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
        builder
           .HasOne(x => x.AnimalType)
           .WithMany()
           .HasForeignKey(x => x.AnimalTypeId);

        base.Configure(builder);
    }
}
