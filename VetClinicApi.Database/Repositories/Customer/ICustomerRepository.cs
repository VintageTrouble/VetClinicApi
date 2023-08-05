using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public interface ICustomerRepository : IAbstractRepository<Customer>
{
    Task<Customer?> GetByPassportNumber(string pasportNumber);

}
