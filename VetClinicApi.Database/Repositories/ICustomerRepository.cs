using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories
{
    public interface ICustomerRepository : IAbstractRepository<Customer>
    {
        Customer GetByPassportNumber(string pasportNumber);
        
    }
}
