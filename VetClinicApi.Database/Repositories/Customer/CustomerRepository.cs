﻿using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    { }

    public async Task<Customer?> GetByPassportNumber(string pasportNumber)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Customers.FirstOrDefaultAsync(x => x.PassportNumber == pasportNumber);
    }
}
