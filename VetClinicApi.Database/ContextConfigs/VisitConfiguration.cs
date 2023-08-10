using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class VisitConfiguration : BaseConfiguration<Visit>
{
    public override void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder
            .ToTable("T_VisitTable")
            .HasKey(x => x.Id);

        builder
            .HasOne<Animal>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        base.Configure(builder);
    }
}
