﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkillsetAPI.Migrations
{
    public partial class dbbtSSetp1ModifyTableNameSet_Group_AccessUp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetGroupAccesses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetGroupAccesses",
                columns: table => new
                {
                    grp_mod_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    can_add = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false),
                    can_edit = table.Column<bool>(nullable: false),
                    can_view = table.Column<bool>(nullable: false),
                    grp_id = table.Column<string>(maxLength: 25, nullable: true),
                    mod_id = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetGroupAccesses", x => x.grp_mod_id);
                });
        }
    }
}
