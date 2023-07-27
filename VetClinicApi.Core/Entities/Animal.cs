using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Core.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsVaccinated { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastEditDate { get; set; }

        public virtual AnimalType AnimalType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
