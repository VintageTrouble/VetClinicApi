using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database;

public class VetClinicContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Animal> Animals { get; set; }
    public virtual DbSet<AnimalType> AnimalTypes { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<ProvidedService> ProvidedServices { get; set; }
    public virtual DbSet<Visit> Visits { get; set; }

    public VetClinicContext(DbContextOptions<VetClinicContext> contextOptions) : base(contextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VetClinicContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
