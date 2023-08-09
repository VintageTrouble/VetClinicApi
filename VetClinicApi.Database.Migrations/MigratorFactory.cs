using FluentMigrator.Runner;

using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Database.Migrations.Common;

namespace VetClinicApi.Database.Migrations;

public static class MigratorFactory
{
    public static IMigrationRunner CreateRunner(string connectionString)
    {
        var migrator = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(IAssemblyMarker).Assembly)
                .For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        var scope = migrator.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        return runner;
    }
}
