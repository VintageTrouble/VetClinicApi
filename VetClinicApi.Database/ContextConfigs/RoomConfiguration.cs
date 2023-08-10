using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class RoomConfiguration : BaseConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .ToTable("T_Room")
            .HasKey(x => x.Id);

        base.Configure(builder);
    }
}
