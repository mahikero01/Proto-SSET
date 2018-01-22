using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1AddTableDepartmentSkillsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "SS_Departments",
                newName: "DepartmentID");

            migrationBuilder.CreateTable(
                name: "SS_DepartmentSkillsets",
                columns: table => new
                {
                    DepartmentSkillsetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentID = table.Column<int>(nullable: false),
                    SkilsetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_DepartmentSkillsets", x => x.DepartmentSkillsetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SS_DepartmentSkillsets");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "SS_Departments",
                newName: "DepartmentId");
        }
    }
}
