using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateProvidedServiceTable)]
public class Migration_006_ProvidedServiceListTable : Migration
{
    public override void Up()
    {
        Create.Table("T_ProvidedService")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("T_ProvidedService");
    }
}
