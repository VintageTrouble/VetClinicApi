using FluentMigrator;

using VetClinicApi.Core.Enums;
using VetClinicApi.Database.Migrations.Migrations.Abstract;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateRoomTypeTable)]
public class Migration_004_CreateRoomTypeTable : EnumMigration<RoomType>
{ }
