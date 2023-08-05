using FluentMigrator.Runner.Logging;

namespace VetClinicApi.Database.Migrations;

public static class MigrationVersioning
{
    public const long MaxVersion = CreateAnimalTable;

    public const long CreateCustomerTable = 1;
    public const long CreateAnimalTypeTable = 2;
    public const long CreateAnimalTable = 3;
}
