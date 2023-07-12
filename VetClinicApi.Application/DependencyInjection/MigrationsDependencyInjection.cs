using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Database.Migrations;

namespace VetClinicApi.Application.DependencyInjection;

public static class MigrationsDependencyInjection
{
    public static IServiceCollection AddMigrations(this IServiceCollection services, string connectionString)
    {
        var runner = MigratorFactory.CreateRunner(connectionString);

        services.AddSingleton(runner);

        runner.MigrateUp(MigrationVersioning.MaxVersion);

        return services;
    }
}
