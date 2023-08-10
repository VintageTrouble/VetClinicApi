using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class ProvidedServiceRepository : AbstractRepository<ProvidedService>, IProvidedServiceRepository
{
    public ProvidedServiceRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }
}
