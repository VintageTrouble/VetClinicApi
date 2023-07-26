using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.CustomerHandlig;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Customer CreateCustomer(Customer? customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer can't be null.");

        if (_repository.GetByPassportNumber(customer.PassportNumber) is not null)
            throw new PassportNumberConflictExceprion("PassportNumber are already in use.");

        customer.RegistrationDate = DateTime.Today;
        customer.LastEditDate = DateTime.Today;
        customer.LastVisitDate = null;

        return _repository.Add(customer);
    }

    public Customer UpdateCustomer(Customer? customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer can't be null.");

        if (_repository.GetById(customer.Id) is not Customer databaseCustomer)
            throw new CustomerNotFoundException(customer.Id);

        if (databaseCustomer.LastVisitDate is not null && customer.LastVisitDate is null)
            throw new ValueTurnsToNullException(nameof(customer.LastVisitDate));

        customer.LastEditDate = DateTime.Today;
        customer.RegistrationDate = databaseCustomer.RegistrationDate;
        try
        {
            return _repository.Update(customer);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new CustomerNotFoundException(customer.Id);
        }
    }

    public Customer GetCustomer(int id)
    {
        if (_repository.GetById(id) is not Customer customer)
            throw new CustomerNotFoundException(id);

        return customer;
    }
}
