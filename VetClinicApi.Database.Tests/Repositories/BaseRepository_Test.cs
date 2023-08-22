using VetClinicApi.Database.Repositories.Base;
using VetClinicApi.Database.Tests.Repositories.Abstract;
using VetClinicApi.Database.Tests.Repositories.TestData;

using Xunit;

namespace VetClinicApi.Database.Tests.Repositories;

public class BaseRepository_Test : ContextFactoryCreator
{
    [Fact]
    public async Task Update_EntityNotFound_Throw_ArgumentOutOfRangeException()
    {
        var repository = new BaseRepository<TestEntity>(_dbContextFactory);

        var testEntity = new TestEntity { Id = 1 };

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await repository.Update(testEntity));
    }

    [Fact]
    public async Task Delete_EntityNotFound_Throw_ArgumentOutOfRangeException()
    {
        var repository = new BaseRepository<TestEntity>(_dbContextFactory);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await repository.Delete(1));
    }
}
