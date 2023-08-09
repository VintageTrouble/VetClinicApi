using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Database.Migrations;
using VetClinicApi.Database.Migrations.Migrations;

namespace VetClinicApi.Application.DependencyInjection;

public static class MigrationsDependencyInjection
{
    public static IServiceCollection AddMigrations(this IServiceCollection services, string connectionString)
    {
        var runner = MigratorFactory.CreateRunner(connectionString);

        services.AddSingleton(runner);

        runner.MigrateUp(MigrationVersioning.MaxVersion);
        runner.Up(new Migration_Final());

        return services;
    }
}
