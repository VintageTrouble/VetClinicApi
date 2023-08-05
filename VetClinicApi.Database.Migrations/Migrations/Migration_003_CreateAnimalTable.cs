using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateAnimalTable)]
public class Migration_003_CreateAnimalTable : Migration
{
    public override void Up()
    {
        Create.Table("T_Animal")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .WithColumn("AnimalTypeId").AsInt32().NotNullable()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Breed").AsString().NotNullable()
            .WithColumn("BirthDate").AsDate().NotNullable()
            .WithColumn("IsVaccinated").AsBoolean().NotNullable()
            .WithColumn("RegistrationDate").AsDateTime().NotNullable()
            .WithColumn("LastEditDate").AsDateTime().NotNullable();

        Create.ForeignKey("FK_AnimalCustomer")
            .FromTable("T_Animal").ForeignColumn("CustomerId").ToTable("T_Customer").PrimaryColumn("Id");
        Create.ForeignKey("FK_AnimalAnimalType")
            .FromTable("T_Animal").ForeignColumn("AnimalTypeId").ToTable("T_AnimalType").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.ForeignKey("FK_AnimalAnimalType").OnTable("T_Animal");
        Delete.ForeignKey("FK_AnimalCustomer").OnTable("T_Animal");
        Delete.Table("T_Animal");
    }
}
