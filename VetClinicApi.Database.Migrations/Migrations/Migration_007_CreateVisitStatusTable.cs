using FluentMigrator;

using VetClinicApi.Core.Enums;
using VetClinicApi.Database.Migrations.Migrations.Abstract;

namespace VetClinicApi.Database.Migrations.Migrations;

[Migration(MigrationVersioning.CreateVisitStatusTable)]
public class Migration_007_CreateVisitStatusTable : EnumMigration<VisitStatus>
{ }
