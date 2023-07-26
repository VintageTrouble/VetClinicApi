using Microsoft.Extensions.DependencyInjection;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Application.Services.ExceptionHandling;

namespace VetClinicApi.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExceptionHandlerService, ExceptionHandlerService>();
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}
