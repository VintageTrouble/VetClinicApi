using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database
{
    public class VetClinicContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public VetClinicContext(DbContextOptions<VetClinicContext> contextOptions) : base(contextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("T_Customer")
                .HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
