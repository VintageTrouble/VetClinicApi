using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations.Abstract;

public abstract class EnumMigration<TEnum> : Migration
    where TEnum : Enum
{
    public override void Up()
    {
        Create.Table($"T_{typeof(TEnum).Name}")
            .WithColumn("Id").AsInt32().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable().Unique();
    }

    public override void Down()
    {
        Delete.Table($"T_{typeof(TEnum).Name}");
    }
}
