using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Enums;
using VetClinicApi.Core.Extensions;

namespace VetClinicApi.Database;

public class VetClinicContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Animal> Animals { get; set; }
    public virtual DbSet<AnimalType> AnimalTypes { get; set; }
    public VetClinicContext(DbContextOptions<VetClinicContext> contextOptions) : base(contextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .ToTable("T_Customer")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Customer>()
            .Property(x => x.BirthDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());
        modelBuilder.Entity<Customer>()
            .Property(x => x.RegistrationDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());
        modelBuilder.Entity<Customer>()
            .Property(x => x.LastEditDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());
        modelBuilder.Entity<Customer>()
            .Property(x => x.LastVisitDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());

        modelBuilder.Entity<Animal>()
            .ToTable("T_Animal")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Animal>()
            .Property(x => x.BirthDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());
        modelBuilder.Entity<Animal>()
            .Property(x => x.RegistrationDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());
        modelBuilder.Entity<Animal>()
            .Property(x => x.LastEditDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());

        modelBuilder.Entity<Animal>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
        modelBuilder.Entity<Animal>()
           .HasOne(x => x.AnimalType)
           .WithMany()
           .HasForeignKey(x => x.AnimalTypeId);

        modelBuilder.Entity<AnimalType>()
            .ToTable("T_AnimalType")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Room>()
            .ToTable("T_Room")
            .HasKey(x => x.Id);

        modelBuilder.Entity<PriceList>()
            .ToTable("T_PriceList")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Visit>()
            .ToTable("T_VisitTable")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Visit>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        modelBuilder.Entity<Visit>()
            .Property(x => x.VisitDate)
                .HasConversion(
                    src => src.ToUnspecifiedKind(),
                    dst => dst.ToUnspecifiedKind());


        base.OnModelCreating(modelBuilder);
    }
}
