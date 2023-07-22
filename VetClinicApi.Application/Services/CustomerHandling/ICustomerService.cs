using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.CustomerHandlig
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
    }
}
