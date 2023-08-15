using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public interface IVisitRepository : IAbstractRepository<Visit>
{
    Task<IEnumerable<Visit>> GetAllByFilter(DateTime dateTime);
}
