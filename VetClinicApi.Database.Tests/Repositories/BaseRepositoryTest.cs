using Microsoft.EntityFrameworkCore;

using Moq;

using VetClinicApi.Database.Tests.Repositories.TestData;

namespace VetClinicApi.Database.Tests.Repositories;

public abstract class BaseRepositoryTest
{
	protected IDbContextFactory<VetClinicContext> _dbContextFactory;
	private readonly Mock<IDbContextFactory<VetClinicContext>> _contextFactoryMock = new();

	public BaseRepositoryTest()
	{
		var options = new DbContextOptionsBuilder<VetClinicContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString())
			.Options;

		_contextFactoryMock
			.Setup(x => x.CreateDbContext())
			.Returns(() => new TestContext(options));

		_dbContextFactory = _contextFactoryMock.Object;
	}
}
