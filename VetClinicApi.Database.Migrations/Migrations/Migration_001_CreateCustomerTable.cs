using FluentMigrator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Database.Migrations.Migrations
{
    [Migration(MigrationVersioning.CreateCustomerTable)]
    public class Migration_001_CreateCustomerTable : Migration
    {
        public override void Up()
        {
            Create.Table("T_Customer")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("PassportNumber").AsString().Unique().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable()
                .WithColumn("BirthDate").AsDate().NotNullable()
                .WithColumn("RegistrationDate").AsDateTime().NotNullable()
                .WithColumn("LastEditDate").AsDateTime().NotNullable()
                .WithColumn("LastVisitDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("T_Customer");
        }
    }
}
