using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Core.Entities
{
    public class AnimalType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
