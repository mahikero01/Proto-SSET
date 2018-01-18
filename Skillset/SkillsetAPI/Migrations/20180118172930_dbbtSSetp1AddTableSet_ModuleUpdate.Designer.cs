﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SkillsetAPI.Entities;
using System;

namespace SkillsetAPI.Migrations
{
    [DbContext(typeof(SkillSetContext))]
    [Migration("20180118172930_dbbtSSetp1AddTableSet_ModuleUpdate")]
    partial class dbbtSSetp1AddTableSet_ModuleUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkillsetAPI.Entities.SetGroup", b =>
                {
                    b.Property<string>("grp_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<DateTime>("created_date");

                    b.Property<string>("grp_desc")
                        .HasMaxLength(255);

                    b.Property<string>("grp_name")
                        .HasMaxLength(50);

                    b.HasKey("grp_id");

                    b.ToTable("set_group");
                });

            modelBuilder.Entity("SkillsetAPI.Entities.SetModule", b =>
                {
                    b.Property<string>("mod_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<DateTime>("created_date");

                    b.Property<string>("mod_desc")
                        .HasMaxLength(255);

                    b.Property<string>("mod_name")
                        .HasMaxLength(50);

                    b.HasKey("mod_id");

                    b.ToTable("set_module");
                });

            modelBuilder.Entity("SkillsetAPI.Entities.SetUser", b =>
                {
                    b.Property<string>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25);

                    b.Property<bool>("can_DEV");

                    b.Property<bool>("can_PEER");

                    b.Property<bool>("can_PROD");

                    b.Property<bool>("can_UAT");

                    b.Property<DateTime>("created_date");

                    b.Property<string>("user_first_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_last_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_middle_name")
                        .HasMaxLength(50);

                    b.Property<string>("user_name")
                        .HasMaxLength(25);

                    b.HasKey("user_id");

                    b.ToTable("set_user");
                });

            modelBuilder.Entity("SkillsetAPI.Entities.SetUserAccess", b =>
                {
                    b.Property<int>("user_grp_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("grp_id")
                        .HasMaxLength(25);

                    b.Property<string>("user_id")
                        .HasMaxLength(25);

                    b.HasKey("user_grp_id");

                    b.ToTable("set_user_access");
                });
#pragma warning restore 612, 618
        }
    }
}
