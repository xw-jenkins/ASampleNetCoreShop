using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Members.Api.Migrations
{
    public partial class update_ums_table_IntegrationConsumeSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CouponStatus",
                table: "ums_integration_consume_setting",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CouponStatus",
                table: "ums_integration_consume_setting",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
