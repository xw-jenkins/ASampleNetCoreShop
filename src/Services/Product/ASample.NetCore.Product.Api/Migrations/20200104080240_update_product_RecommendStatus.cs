using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class update_product_RecommendStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommandStatus",
                table: "pms_product");

            migrationBuilder.AddColumn<bool>(
                name: "RecommendStatus",
                table: "pms_product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommendStatus",
                table: "pms_product");

            migrationBuilder.AddColumn<bool>(
                name: "RecommandStatus",
                table: "pms_product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
