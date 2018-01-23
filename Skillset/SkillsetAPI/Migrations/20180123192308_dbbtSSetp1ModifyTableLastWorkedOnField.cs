using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1ModifyTableLastWorkedOnField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastWorkedOn",
                table: "SS_AssociateDepartmentSkillsets",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWorkedOn",
                table: "SS_AssociateDepartmentSkillsets");
        }
    }
}
