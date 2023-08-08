using FluentMigrator;

using VetClinicApi.Core.Enums;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateRoomTypeTable)]
public class Migration_004_CreateRoomTypeTable : Migration
{
    public override void Up()
    {
        Create.Table("T_RoomType")
               .WithColumn("Id").AsInt32().PrimaryKey()
               .WithColumn("Name").AsString().NotNullable().Unique();

        foreach(var type in Enum.GetValues<RoomType>())
        {
            Insert.IntoTable("T_RoomType").Row(new { Id = (int)type, Name = Enum.GetName(type) });
        }
    }
    public override void Down()
    {
        Delete.FromTable("T_RoomType").AllRows();

        Delete.Table("T_RoomType");
    }
}
