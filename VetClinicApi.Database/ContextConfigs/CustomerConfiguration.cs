using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.ContextConfigs.Abstract;

namespace VetClinicApi.Database.ContextConfigs;

public class CustomerConfiguration : BaseConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .ToTable("T_Customer")
            .HasKey(x => x.Id);

        base.Configure(builder);
    }
}
