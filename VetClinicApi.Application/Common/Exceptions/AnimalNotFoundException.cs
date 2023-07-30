using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions;

public class AnimalNotFoundException : BaseApplicationException
{
    public AnimalNotFoundException(int id) : base(HttpStatusCode.BadRequest, $"Animal with id = {id} not found.")
    {
    }
}

