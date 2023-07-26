using System.Net;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions;

public class CustomerNotFoundException : BaseApplicationException
{
    public CustomerNotFoundException(int id) : base(HttpStatusCode.BadRequest, $"Customer with id = {id} not found.")
    {
    }
}
