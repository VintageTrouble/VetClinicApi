using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Infrastructure.DateTimeProvider;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.CustomerHandlig;

public class CustomerService : ICustomerService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ICustomerRepository _repository;

    public CustomerService (IDateTimeProvider dateTimeProvider, ICustomerRepository repository)
    {
        _dateTimeProvider = dateTimeProvider;
        _repository = repository;
    }

    public async Task<Customer> CreateCustomer(Customer? customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer can't be null.");

        if (await _repository.GetByPassportNumber(customer.PassportNumber) is not null)
            throw new PassportNumberConflictExceprion("PassportNumber are already in use.");

        customer.CreationDate = _dateTimeProvider.UtcNow;
        customer.LastEditDate = _dateTimeProvider.UtcNow;
        customer.LastVisitDate = null;

        return await _repository.Add(customer);
    }

    public async Task<Customer> UpdateCustomer(Customer? customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer can't be null.");

        if (await _repository.GetById(customer.Id) is not Customer databaseCustomer)
            throw new CustomerNotFoundException(customer.Id);

        if (databaseCustomer.LastVisitDate is not null && customer.LastVisitDate is null)
            throw new ValueTurnsToNullException(nameof(customer.LastVisitDate));

        customer.LastEditDate = _dateTimeProvider.UtcNow;
        customer.CreationDate = databaseCustomer.CreationDate;
        try
        {
            return await _repository.Update(customer);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new CustomerNotFoundException(customer.Id);
        }
    }

    public async Task<Customer> GetCustomer(int id)
    {
        if (await _repository.GetById(id) is not Customer customer)
            throw new CustomerNotFoundException(id);

        return customer;
    }
}
