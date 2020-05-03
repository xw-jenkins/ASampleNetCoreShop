using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class update_product_filed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailMobile_Html",
                table: "pms_product");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeightTemplateId",
                table: "pms_product",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AlbumPics",
                table: "pms_product",
                maxLength: 2500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailMobileHtml",
                table: "pms_product",
                maxLength: 2500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailMobileHtml",
                table: "pms_product");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeightTemplateId",
                table: "pms_product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlbumPics",
                table: "pms_product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailMobile_Html",
                table: "pms_product",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: true);
        }
    }
}
