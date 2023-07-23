namespace VetClinicApi.Application.Services.ExceptionHandling;

public interface IExceptionHandlerService
{
    (int statusCode, string message) HandleException(Exception? exception);
}
