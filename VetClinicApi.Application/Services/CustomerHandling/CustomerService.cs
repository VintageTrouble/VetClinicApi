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
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer can't be null.");
            }
            customer.RegistrationDate = DateTime.Today;
            customer.LastEditDate = DateTime.Today;
            customer.LastVisitDate = null;
            return _repository.Add(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer can't be null.");
            }
            customer.LastEditDate = DateTime.Today;
            return _repository.Update(customer);
        }

        public Customer GetCustomer(int id)
        {
            if(_repository.GetById(id) is not Customer customer)
            {
                throw new ArgumentOutOfRangeException("Customer ID is not exist");
            }
            return customer;
        }
    }
}
