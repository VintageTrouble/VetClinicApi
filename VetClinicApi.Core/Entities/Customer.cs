
namespace VetClinicApi.Core.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public DateTime? LastVisitDate { get; set; }

    }

}
