using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public interface ICustomerRepository : IAbstractRepository<Customer>
{
    Customer? GetByPassportNumber(string pasportNumber);

}
