using VetClinicApi.Core.Entities.Interfaces;
using VetClinicApi.Core.Enums;

namespace VetClinicApi.Core.Entities
{
    public class Visit : ITrackableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
