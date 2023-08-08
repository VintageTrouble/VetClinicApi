using FluentMigrator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Database.Migrations.Migrations
{
    [Migration(MigrationVersioning.CreateRoomTable)]
    public class Migration_005_CreateRoomTable : Migration
    {
        public override void Up()
        {
            Create.Table("T_Room")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("RoomType").AsInt32().NotNullable();

            Create.ForeignKey("FK_RoomRoomType")
                .FromTable("T_Room").ForeignColumn("RoomType").ToTable("T_RoomType").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.ForeignKey("FK_RoomRoomType").OnTable("T_Room");
            Delete.Table("T_Room");
        }
    }
}
