using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class PriceListRepository : AbstractRepository<PriceList>, IPriceListRepository
{
    public PriceListRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }
}
