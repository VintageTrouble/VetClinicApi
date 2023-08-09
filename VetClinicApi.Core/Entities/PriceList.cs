namespace VetClinicApi.Core.Entities;

public class PriceList : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
