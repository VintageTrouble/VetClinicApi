using VetClinicApi.API.Swagger;

namespace VetClinicApi.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthentication();

        services.AddControllers();

        services.AddSwagger();

        return services;
    }
}
