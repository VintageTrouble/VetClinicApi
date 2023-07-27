using FluentMigrator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateAnimalTable)]
public class Migration_002_CreateAnimalTable : Migration
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
            .WithColumn("IsVaccinate").AsBoolean().NotNullable()
            .WithColumn("RegistrationDate").AsDateTime().NotNullable()
            .WithColumn("LastEditDate").AsDateTime().NotNullable();
        Create.Table("T_AnimalType")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable();

        Create.ForeignKey("FK_AnimalCustomer")
            .FromTable("T_Animal").ForeignColumn("CustomerId").ToTable("T_Customer").PrimaryColumn("Id");
        Create.ForeignKey("FK_AnimalAnimalType")
            .FromTable("T_Animal").ForeignColumn("AnimalTypeId").ToTable("T_AnimalType").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.ForeignKey("FK_AnimalAnimalType");
        Delete.ForeignKey("FK_AnimalCustomer");
        Delete.Table("T_AnimalType");
        Delete.Table("T_Animal");
    }
}
