using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.RenameCustomerRegistrationDateColumnToCreationDate)]
public class Migration_009_RenameCustomerRegistrationDateColumnToCreationDate : Migration
{
    public override void Up()
    {
        Rename.Column("RegistrationDate").OnTable("T_Customer").To("CreationDate");
    }

    public override void Down()
    {
        Rename.Column("CreationDate").OnTable("T_Customer").To("RegistrationDate");
    }
}
