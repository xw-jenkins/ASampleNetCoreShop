using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Identity.Api.Migrations
{
    public partial class updateuserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAvatar",
                table: "IdentityUser",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UserStatus",
                table: "IdentityUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAvatar",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "IdentityUser");
        }
    }
}
