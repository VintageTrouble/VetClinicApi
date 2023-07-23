using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Extensions;

namespace VetClinicApi.Database
{
    public class VetClinicContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
