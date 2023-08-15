using FluentMigrator;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.UpdateVisitTable)]
public class Migration_009_UpdateVisitTable : Migration
{
    public override void Up()
    {
        Alter.Table("T_Visit")
            .AddColumn("RoomId")
            .AsInt32()
            .NotNullable()
            .SetExistingRowsTo(0);

        Create.ForeignKey("FK_VisitRoom")
            .FromTable("T_Visit").ForeignColumn("RoomId").ToTable("Room").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.ForeignKey("FK_VisitRoom").OnTable("T_Visit");

        Delete.Column("RoomId").FromTable("T_Visit");
    }
}
