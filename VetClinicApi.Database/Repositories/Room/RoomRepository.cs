using Microsoft.EntityFrameworkCore;

using VetClinicApi.Core.Entities;

namespace VetClinicApi.Database.Repositories;

public class RoomRepository : AbstractRepository<Room>, IRoomRepository
{
    public RoomRepository(IDbContextFactory<VetClinicContext> contextFactory) : base(contextFactory)
    {
    }
}
