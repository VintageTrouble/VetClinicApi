using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateAnimalTypeTable)]
public class Migration_002_CreateAnimalTypeTable : Migration
{
    public override void Up()
    {
        Create.ForeignKey("FK_AnimalCustomer")
            .FromTable("T_Animal").ForeignColumn("CustomerId").ToTable("T_Customer").PrimaryColumn("Id");
        Create.ForeignKey("FK_AnimalAnimalType")
            .FromTable("T_Animal").ForeignColumn("AnimalTypeId").ToTable("T_AnimalType").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.ForeignKey("FK_AnimalAnimalType");
        Delete.Table("T_AnimalType");
    }
}
