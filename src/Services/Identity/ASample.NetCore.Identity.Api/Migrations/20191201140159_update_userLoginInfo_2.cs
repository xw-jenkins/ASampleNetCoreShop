using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Identity.Api.Migrations
{
    public partial class update_userLoginInfo_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin");

            migrationBuilder.AlterColumn<string>(
                name: "LoginIp",
                table: "IdentityUserLogin",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IdentityUserLogin_LoginProvider_ProviderKey",
                table: "IdentityUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_IdentityUserLogin_LoginProvider_ProviderKey",
                table: "IdentityUserLogin");

            migrationBuilder.AlterColumn<string>(
                name: "LoginIp",
                table: "IdentityUserLogin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });
        }
    }
}
