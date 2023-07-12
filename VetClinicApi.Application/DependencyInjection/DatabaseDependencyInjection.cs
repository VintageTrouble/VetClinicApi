using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Database;

namespace VetClinicApi.Application.DependencyInjection;

public static class DatabaseDependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<VetClinicContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
