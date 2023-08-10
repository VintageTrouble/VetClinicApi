using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class PriceListConfiguration : BaseConfiguration<PriceList>
{
    public override void Configure(EntityTypeBuilder<PriceList> builder)
    {
        builder
            .ToTable("T_PriceList")
            .HasKey(x => x.Id);

        base.Configure(builder);
    }
}
