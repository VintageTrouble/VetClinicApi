namespace VetClinicApi.Core.Entities;

public class AnimalType : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
