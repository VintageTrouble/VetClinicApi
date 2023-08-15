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
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        builder
            .HasOne(x => x.Room)
            .WithMany()
            .HasForeignKey(x => x.RoomId);

        base.Configure(builder);
    }
}
