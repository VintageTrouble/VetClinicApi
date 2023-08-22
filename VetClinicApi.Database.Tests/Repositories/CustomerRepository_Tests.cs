using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;
using VetClinicApi.Database.Tests.Repositories.Abstract;
using Xunit;

namespace VetClinicApi.Database.Tests.Repositories;

public class CustomerRepository_Tests : ContextFactoryCreator
{
    [Fact]
    public async Task GetByPassportNumber()
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.Add(new Customer
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.MaxValue,
                PassportNumber = "123",
                PhoneNumber = "321",
                RegistrationDate = DateTime.MaxValue,
                LastEditDate = DateTime.MaxValue
            });

            context.SaveChanges();
        }

        var repository = new CustomerRepository(_dbContextFactory);

        var result = await repository.GetByPassportNumber("123");

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }
}
