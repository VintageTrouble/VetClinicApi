using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions;

public class AnimalTypeNotFoundException : BaseApplicationException
{
    public AnimalTypeNotFoundException(int id) : base(HttpStatusCode.BadRequest, $"AnimalType with id = {id} not found.")
    {
    }
}
