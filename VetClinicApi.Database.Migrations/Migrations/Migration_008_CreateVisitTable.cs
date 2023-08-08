using FluentMigrator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VetClinicApi.Core.Enums;

namespace VetClinicApi.Database.Migrations.Migrations;

public class Migration_008_CreateVisitTable : Migration
{

    public override void Up()
    {
        Create.Table("T_Visit")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .WithColumn("VisitStatus").AsInt32().NotNullable()
            .WithColumn("VisitDate").AsDateTime().NotNullable();

        Create.ForeignKey("FK_VisitCustomer")
            .FromTable("T_Visit").ForeignColumn("CustomerId").ToTable("T_Customer").PrimaryColumn("Id");
        Create.ForeignKey("FK_VisitVisitStatus")
            .FromTable("T_Visit").ForeignColumn("VisitStatus").ToTable("T_VisitStatus").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.ForeignKey("FK_VisitVisitStatus").OnTable("T_Visit");
        Delete.ForeignKey("FK_VisitCustomer").OnTable("T_Visit");

        Delete.Table("T_Visit");
    }
}
