using FluentMigrator;

using VetClinicApi.Core.Enums;

namespace VetClinicApi.Database.Migrations.Migrations;

public class Migration_007_CreateVisitStatusTable : Migration
{
    public override void Up()
    {
        Create.Table("T_VisitStatus")
            .WithColumn("Id").AsInt32().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable().Unique();

        foreach (var status in Enum.GetValues<VisitStatus>())
        {
            Insert.IntoTable("T_VisitStatus").Row(new { Id = (int)status, Name = Enum.GetName(status) });
        }
    }
    public override void Down()
    {
        Delete.FromTable("T_VisitStatus").AllRows();

        Delete.Table("T_VisitStatus");
    }

}
