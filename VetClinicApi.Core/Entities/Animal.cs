using VetClinicApi.Core.Entities.Interfaces;

namespace VetClinicApi.Core.Entities;

public class Animal : ITrackableEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int AnimalTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public bool IsVaccinated { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastEditDate { get; set; }

    public virtual AnimalType? AnimalType { get; set; }
    public virtual Customer? Customer { get; set; }
}
