using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.RenameAnimalRegistrationDateColumnToCreationDate)]
public class Migration_010_RenameAnimalRegistrationDateColumnToCreationDate : Migration
{
    public override void Up()
    {
        Rename.Column("RegistrationDate").OnTable("T_Animal").To("CreationDate");
    }

    public override void Down()
    {
        Rename.Column("CreationDate").OnTable("T_Animal").To("RegistrationDate");
    }
}
