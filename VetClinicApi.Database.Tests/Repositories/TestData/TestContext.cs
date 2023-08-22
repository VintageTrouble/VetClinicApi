using Microsoft.EntityFrameworkCore;

namespace VetClinicApi.Database.Tests.Repositories.TestData;

internal class TestContext : VetClinicContext
{
    public DbSet<TestEntity> TestEntities { get; set; }

    public TestContext(DbContextOptions<VetClinicContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
