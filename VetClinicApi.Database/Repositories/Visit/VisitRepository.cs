using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class VisitRepository : AbstractRepository<Visit>, IVisitRepository
{
    public VisitRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }
}
