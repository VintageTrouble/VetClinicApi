using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Entities.Interfaces;

namespace VetClinicApi.Database.Tests.Repositories.TestData;

internal class TestEntity : IEntity
{
    public int Id { get; set; }
}
