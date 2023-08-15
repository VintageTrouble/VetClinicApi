using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Enums;

namespace VetClinicApi.Database.Repositories;

public class VisitRepository : AbstractRepository<Visit>, IVisitRepository
{
    public VisitRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }

    public async Task<IEnumerable<Visit>> GetAllByFilter(DateTime dateTime)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Visits
           .Where(x => x.VisitDate == dateTime && x.VisitStatus == VisitStatus.Waiting)
           .ToListAsync();
    }
}
