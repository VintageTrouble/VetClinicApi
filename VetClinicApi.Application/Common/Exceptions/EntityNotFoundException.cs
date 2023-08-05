using System.Net;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions
{
    public class EntityNotFoundException : BaseApplicationException
    {
        public EntityNotFoundException(int id, string entity) : base(HttpStatusCode.BadRequest, $"{entity} with id = {id} not found.")
        {
        }
    }
}
