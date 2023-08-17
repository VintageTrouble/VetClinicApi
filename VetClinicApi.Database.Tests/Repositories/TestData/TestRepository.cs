using Microsoft.EntityFrameworkCore;

using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Database.Tests.Repositories.TestData;

internal class TestRepository : AbstractRepository<TestEntity>
{
    public TestRepository(IDbContextFactory<VetClinicContext> contextFactory)
        : base(contextFactory)
    { }
}
