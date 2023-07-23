using System.Net;

using VetClinicApi.Application.Common.Exceptions.Abstract;

namespace VetClinicApi.Application.Services.ExceptionHandling;

public class ExceptionHandlerService : IExceptionHandlerService
{
    public (int statusCode, string message) HandleException(Exception? exception)
    => exception switch
    {
        BaseApplicationException applicationException => ((int)applicationException.StatusCode, applicationException.Message),
        _ => ((int)HttpStatusCode.InternalServerError, exception?.Message ?? "Unexpected error occured.")
    };
}
