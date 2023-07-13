using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Application.Services.CustomerHandlig;

namespace VetClinicApi.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}
