using VetClinicApi.Database.Tests.Repositories.TestData;

using Xunit;

namespace VetClinicApi.Database.Tests.Repositories;

public class AbstractRepository_Test : BaseRepositoryTest
{
    [Fact]
    public async Task Update_EntityNotFound_Throw_ArgumentOutOfRangeException()
    {
        var repository = new TestRepository(_dbContextFactory);

        var testEntity = new TestEntity { Id = 1 };

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await repository.Update(testEntity));
    }

    [Fact]
    public async Task Delete_EntityNotFound_Throw_ArgumentOutOfRangeException()
    {
        var repository = new TestRepository(_dbContextFactory);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await repository.Delete(1));
    }
}
