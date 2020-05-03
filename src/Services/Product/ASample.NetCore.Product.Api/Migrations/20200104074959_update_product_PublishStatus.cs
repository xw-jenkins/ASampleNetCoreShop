using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class update_product_PublishStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicStatus",
                table: "pms_product");

            migrationBuilder.AddColumn<bool>(
                name: "PublishStatus",
                table: "pms_product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishStatus",
                table: "pms_product");

            migrationBuilder.AddColumn<bool>(
                name: "PublicStatus",
                table: "pms_product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
