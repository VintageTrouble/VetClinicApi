using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Application.Infrastructure.DateTimeProvider;
using VetClinicApi.Application.Services.AnimalHandling;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Application.Services.ExceptionHandling;
using VetClinicApi.Application.Services.ProvidedServiceHandling;

namespace VetClinicApi.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IExceptionHandlerService, ExceptionHandlerService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAnimalService, AnimalService>();
        services.AddScoped<IProvidedServiceService, ProvidedServiceService>();

        return services;
    }
}
