﻿// <auto-generated />
using System;
using ASample.NetCore.Members.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASample.NetCore.Members.Api.Migrations
{
    [DbContext(typeof(MemberApiContext))]
    [Migration("20191216232348_update_member_level")]
    partial class update_member_level
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASample.NetCore.Members.Api.Domain.AggregateRoots.MemberLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CommentGrowthPoint")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DefaultStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FreeFreightPoint")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GrowthPoint")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("PriviledgeBirthday")
                        .HasColumnType("bit");

                    b.Property<bool>("PriviledgeComment")
                        .HasColumnType("bit");

                    b.Property<bool>("PriviledgeFreeFreight")
                        .HasColumnType("bit");

                    b.Property<bool>("PriviledgeMemberPrice")
                        .HasColumnType("bit");

                    b.Property<bool>("PriviledgePromotion")
                        .HasColumnType("bit");

                    b.Property<bool>("PriviledgeSignIn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ums_member_level");
                });
#pragma warning restore 612, 618
        }
    }
}
