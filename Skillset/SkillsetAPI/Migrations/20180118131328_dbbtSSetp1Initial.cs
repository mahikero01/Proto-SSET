using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "set_user",
                columns: table => new
                {
                    user_id = table.Column<string>(maxLength: 25, nullable: false),
                    can_DEV = table.Column<bool>(nullable: false),
                    can_PEER = table.Column<bool>(nullable: false),
                    can_PROD = table.Column<bool>(nullable: false),
                    can_UAT = table.Column<bool>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    user_first_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_last_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_middle_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set_user", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "set_user");
        }
    }
}
