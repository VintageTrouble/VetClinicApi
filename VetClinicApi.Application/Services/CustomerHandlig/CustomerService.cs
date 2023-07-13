using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.CustomerHandlig
{
    public class CustomerService : ICustomerService
    {
        private readonly IAbstractRepository<Customer> _repository;

        public CustomerService(IAbstractRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            customer.RegistrationDate = DateTime.Now;
            customer.LastEditDate = DateTime.Now;
            customer.LastVisitDate = null;
            return _repository.Add(customer);
            
        }

        public Customer UpdateCustomer(Customer customer)
        {
            customer.LastEditDate = DateTime.Now;
            return _repository.Update(customer);
        }
    }
}
