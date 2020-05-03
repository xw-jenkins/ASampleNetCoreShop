using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Marketing.Api.Migrations
{
    public partial class update_SMS_flashPromotionSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FlashPromotionId",
                table: "sms_flash_promotion_session",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlashPromotionId",
                table: "sms_flash_promotion_session");
        }
    }
}
