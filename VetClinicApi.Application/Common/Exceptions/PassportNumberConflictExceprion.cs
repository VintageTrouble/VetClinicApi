using System.Net;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Common.Exceptions;

public class PassportNumberConflictExceprion : BaseApplicationException
{
    public PassportNumberConflictExceprion(string message) : base(HttpStatusCode.Conflict, message)
    {
    }
}
