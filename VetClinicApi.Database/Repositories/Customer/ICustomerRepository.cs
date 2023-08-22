using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories.Base;

namespace VetClinicApi.Database.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByPassportNumber(string pasportNumber);
}
