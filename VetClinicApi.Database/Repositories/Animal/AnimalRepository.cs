using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class AnimalRepository : AbstractRepository<Animal>, IAnimalRepository
{
    public AnimalRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }
}
