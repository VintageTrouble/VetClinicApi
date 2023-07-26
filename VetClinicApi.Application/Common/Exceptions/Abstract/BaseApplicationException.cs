using System.Net;

namespace VetClinicApi.Application.Common.Exceptions.Abstract;

public abstract class BaseApplicationException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public BaseApplicationException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;   
    }
    public BaseApplicationException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
