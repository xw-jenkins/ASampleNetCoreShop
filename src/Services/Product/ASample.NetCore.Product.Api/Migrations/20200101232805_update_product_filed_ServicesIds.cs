using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class update_product_filed_ServicesIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicesIds",
                table: "pms_product");

            migrationBuilder.AddColumn<string>(
                name: "ServiceIds",
                table: "pms_product",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceIds",
                table: "pms_product");

            migrationBuilder.AddColumn<string>(
                name: "ServicesIds",
                table: "pms_product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
