using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1AddTableSet_Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetGroups",
                columns: table => new
                {
                    grp_id = table.Column<string>(maxLength: 25, nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    grp_desc = table.Column<string>(maxLength: 255, nullable: true),
                    grp_name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetGroups", x => x.grp_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetGroups");
        }
    }
}
