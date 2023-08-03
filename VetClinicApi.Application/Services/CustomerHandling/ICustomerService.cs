using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.CustomerHandlig;

public interface ICustomerService
{
    Task<Customer> CreateCustomer(Customer customer);
    Task<Customer> UpdateCustomer(Customer customer);
    Task<Customer> GetCustomer(int Id);
}
