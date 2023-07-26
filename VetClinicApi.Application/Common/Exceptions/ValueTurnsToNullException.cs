using System.Net;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions;
public class ValueTurnsToNullException : BaseApplicationException
{
    public ValueTurnsToNullException(string property) : base(HttpStatusCode.BadRequest, $"{property} can't be null if it already has value.")
    {
    }
}
