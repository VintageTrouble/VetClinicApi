namespace VetClinicApi.Core.Entities;

public class Customer : IEntity
{
    public int Id { get; set; }
    public string PassportNumber { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastEditDate { get; set; }
    public DateTime? LastVisitDate { get; set; }

}