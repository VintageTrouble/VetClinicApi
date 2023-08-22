using VetClinicApi.Core.Entities.Interfaces;

namespace VetClinicApi.Core.Entities;

public class ProvidedService : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
