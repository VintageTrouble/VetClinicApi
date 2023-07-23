using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories
{
    public class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
        {
        }

        public Customer GetByPassportNumber(string pasportNumber)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var result = context.Customers.FirstOrDefault(x => x.PassportNumber == pasportNumber);
                return result;
            }
        }
    }
}
