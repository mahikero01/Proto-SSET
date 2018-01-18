using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1AddTableSet_ModuleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "set_module",
                columns: table => new
                {
                    mod_id = table.Column<string>(maxLength: 25, nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    mod_desc = table.Column<string>(maxLength: 255, nullable: true),
                    mod_name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set_module", x => x.mod_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "set_module");
        }
    }
}
