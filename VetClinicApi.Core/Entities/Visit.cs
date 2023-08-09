using VetClinicApi.Core.Enums;

namespace VetClinicApi.Core.Entities
{
    public class Visit : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
