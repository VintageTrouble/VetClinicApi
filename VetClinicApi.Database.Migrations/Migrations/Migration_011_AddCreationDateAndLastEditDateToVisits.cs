using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.AddCreationDateAndLastEditDateToVisits)]
public class Migration_011_AddCreationDateAndLastEditDateToVisits : Migration
{
    public override void Up()
    {
        Alter.Table("T_Visit")
            .AddColumn("CreationDate").AsDateTime().NotNullable().SetExistingRowsTo(DateTime.UtcNow)
            .AddColumn("LastEditDate").AsDateTime().NotNullable().SetExistingRowsTo(DateTime.UtcNow);
    }

    public override void Down()
    {
        Delete.Column("CreationDate").FromTable("T_Visit");
        Delete.Column("LastEditDate").FromTable("T_Visit");
    }
}