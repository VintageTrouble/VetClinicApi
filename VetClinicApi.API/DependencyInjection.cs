using FluentValidation.AspNetCore;
using FluentValidation;

using VetClinicApi.API.Common.Mappings;
using VetClinicApi.API.Swagger;
using VetClinicApi.API.Common;

namespace VetClinicApi.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthentication();

        services.AddControllers();

        services.AddSwagger();
        services.AddMappings();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return services;
    }
}
