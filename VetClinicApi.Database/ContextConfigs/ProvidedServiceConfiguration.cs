using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class ProvidedServiceConfiguration : BaseConfiguration<ProvidedService>
{
    public override void Configure(EntityTypeBuilder<ProvidedService> builder)
    {
        builder
            .ToTable("T_ProvidedService")
            .HasKey(x => x.Id);

        base.Configure(builder);
    }
}
