using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateAnimalTypeTable)]
public class Migration_002_CreateAnimalTypeTable : Migration
{
    public override void Up()
    {
        Create.Table("T_AnimalType")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("T_AnimalType");
    }
}
