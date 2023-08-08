using FluentMigrator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApi.Database.Migrations.Migrations
{
    public class Migration_006_CreatePriceListTable : Migration
    {
        public override void Up()
        {
            Create.Table("T_PriceList")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("T_PriceList");
        }
    }
}
