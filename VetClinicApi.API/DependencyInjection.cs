using FluentValidation.AspNetCore;
using FluentValidation;

using VetClinicApi.API.Common.Mappings;
using VetClinicApi.API.Swagger;
using VetClinicApi.API.Common;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VetClinicApi.API.Common.Errors;

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

        services.AddTransient<ProblemDetailsFactory, VetClinicProblemDetailsFactory>();

        return services;
    }
}
