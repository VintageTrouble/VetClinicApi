using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.CustomerHandlig;

public interface ICustomerService
{
    Customer CreateCustomer(Customer customer);
    Customer UpdateCustomer(Customer customer);
    Customer GetCustomer(int Id);
}
