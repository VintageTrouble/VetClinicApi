using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    { }

    public Customer? GetByPassportNumber(string pasportNumber)
    {
        using var context = _contextFactory.CreateDbContext();

        return context.Customers.FirstOrDefault(x => x.PassportNumber == pasportNumber);
    }
}
