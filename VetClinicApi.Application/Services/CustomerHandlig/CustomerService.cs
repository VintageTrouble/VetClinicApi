using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Application.Validation;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.CustomerHandlig
{
    public class CustomerService : ICustomerService
    {
        private readonly IAbstractRepository<Customer> _repository;
        private CustomerValidator _fieldsValidator = new CustomerValidator();

        public CustomerService(IAbstractRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new Exception("Customer in not be null");
            }
            var validate = _fieldsValidator.Validate(customer);
            customer.RegistrationDate = DateTime.Today;
            customer.LastEditDate = DateTime.Today;
            customer.LastVisitDate = null;
            if (!validate.IsValid)
            {
                throw new InvalidOperationException("the customer has not been validated");
            }
            return _repository.Add(customer);

        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("Customer in not be null");
            }
            var validate = _fieldsValidator.Validate(customer);
            customer.LastEditDate = DateTime.Today;
            if (!validate.IsValid)
            {
                throw new InvalidOperationException("the customer has not been validated");
            }
            return _repository.Update(customer);
        }
    }
}
