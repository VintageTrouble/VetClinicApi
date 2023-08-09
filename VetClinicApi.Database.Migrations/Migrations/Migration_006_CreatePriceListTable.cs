using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreatePriceListTable)]
public class Migration_006_CreatePriceListTable : Migration
{
    public override void Up()
    {
        Create.Table("T_PriceList")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("T_PriceList");
    }
}
