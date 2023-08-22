using FluentMigrator;

using System.Reflection;
using VetClinicApi.Core.Entities.Interfaces;

namespace VetClinicApi.Database.Migrations.Migrations;

[Maintenance(MigrationStage.AfterAll)]
public class Migration_Final : Migration
{
    public override void Up()
    {
        var enums = Assembly.GetAssembly(typeof(IEntity))!
            .GetTypes()
            .Where(x => x.Namespace == "VetClinicApi.Core.Enums" && x.IsEnum);

        foreach (var item in enums)
        {
            FillEnum(item, $"T_{item.Name}");
        }
    }

    public override void Down() => throw new InvalidOperationException();

    private void FillEnum(Type enumType, string tableName)
    {
        if (!enumType.IsEnum)
            throw new ArgumentOutOfRangeException(nameof(enumType), "Only enum types are available.");

        Delete.FromTable(tableName).AllRows();

        foreach (var item in Enum.GetValues(enumType))
        {
            Insert.IntoTable(tableName)
                .Row(new { Id = (int)item, Name = Enum.GetName(enumType, item) });
        }
    }
}
