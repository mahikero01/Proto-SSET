using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1ModifyTableNameSet_Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SetGroups",
                table: "SetGroups");

            migrationBuilder.RenameTable(
                name: "SetGroups",
                newName: "set_group");

            migrationBuilder.AddPrimaryKey(
                name: "PK_set_group",
                table: "set_group",
                column: "grp_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_set_group",
                table: "set_group");

            migrationBuilder.RenameTable(
                name: "set_group",
                newName: "SetGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetGroups",
                table: "SetGroups",
                column: "grp_id");
        }
    }
}
