using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Identity.Api.Migrations
{
    public partial class update_IdentityUserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "IdentityUserLogin",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "IdentityUserLogin",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IdentityUserLogin",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LoginIp",
                table: "IdentityUserLogin",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "IdentityUserLogin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "IdentityUserLogin");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IdentityUserLogin");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IdentityUserLogin");

            migrationBuilder.DropColumn(
                name: "LoginIp",
                table: "IdentityUserLogin");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "IdentityUserLogin");
        }
    }
}
