using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Identity.Api.Migrations
{
    public partial class update_allTable_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim_IdentityRole_RoleId",
                table: "IdentityRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim_IdentityUser_UserId",
                table: "IdentityUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin_IdentityUser_UserId",
                table: "IdentityUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_RoleId",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_UserId",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken_IdentityUser_UserId",
                table: "IdentityUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserToken",
                table: "IdentityUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole",
                table: "IdentityUserRole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_IdentityUserRole_UserId_RoleId",
                table: "IdentityUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_IdentityUserLogin_LoginProvider_ProviderKey",
                table: "IdentityUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaim",
                table: "IdentityUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRoleMenuItem",
                table: "IdentityRoleMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRoleClaim",
                table: "IdentityRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRole",
                table: "IdentityRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityMsMenuItem",
                table: "IdentityMsMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityMs",
                table: "IdentityMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityMenu",
                table: "IdentityMenu");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "ums_refresh_token");

            migrationBuilder.RenameTable(
                name: "IdentityUserToken",
                newName: "ums_identity_user_token");

            migrationBuilder.RenameTable(
                name: "IdentityUserRole",
                newName: "ums_identity_user_role");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogin",
                newName: "ums_identity_user_login");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaim",
                newName: "ums_identity_user_claim");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "ums_identity_user");

            migrationBuilder.RenameTable(
                name: "IdentityRoleMenuItem",
                newName: "ums_identity_role_menu_relation");

            migrationBuilder.RenameTable(
                name: "IdentityRoleClaim",
                newName: "ums_identity_role_claim");

            migrationBuilder.RenameTable(
                name: "IdentityRole",
                newName: "ums_identity_role");

            migrationBuilder.RenameTable(
                name: "IdentityMsMenuItem",
                newName: "ums_identity_ms_menu_relation");

            migrationBuilder.RenameTable(
                name: "IdentityMs",
                newName: "ums_identity_ms");

            migrationBuilder.RenameTable(
                name: "IdentityMenu",
                newName: "ums_identity_menu");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserRole_RoleId",
                table: "ums_identity_user_role",
                newName: "IX_ums_identity_user_role_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserLogin_UserId",
                table: "ums_identity_user_login",
                newName: "IX_ums_identity_user_login_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserClaim_UserId",
                table: "ums_identity_user_claim",
                newName: "IX_ums_identity_user_claim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityRoleClaim_RoleId",
                table: "ums_identity_role_claim",
                newName: "IX_ums_identity_role_claim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_refresh_token",
                table: "ums_refresh_token",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_user_token",
                table: "ums_identity_user_token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_user_role",
                table: "ums_identity_user_role",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ums_identity_user_role_UserId_RoleId",
                table: "ums_identity_user_role",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_user_login",
                table: "ums_identity_user_login",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ums_identity_user_login_LoginProvider_ProviderKey",
                table: "ums_identity_user_login",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_user_claim",
                table: "ums_identity_user_claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_user",
                table: "ums_identity_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_role_menu_relation",
                table: "ums_identity_role_menu_relation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_role_claim",
                table: "ums_identity_role_claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_role",
                table: "ums_identity_role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_ms_menu_relation",
                table: "ums_identity_ms_menu_relation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_ms",
                table: "ums_identity_ms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ums_identity_menu",
                table: "ums_identity_menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_role_claim_ums_identity_role_RoleId",
                table: "ums_identity_role_claim",
                column: "RoleId",
                principalTable: "ums_identity_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_user_claim_ums_identity_user_UserId",
                table: "ums_identity_user_claim",
                column: "UserId",
                principalTable: "ums_identity_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_user_login_ums_identity_user_UserId",
                table: "ums_identity_user_login",
                column: "UserId",
                principalTable: "ums_identity_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_user_role_ums_identity_role_RoleId",
                table: "ums_identity_user_role",
                column: "RoleId",
                principalTable: "ums_identity_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_user_role_ums_identity_user_UserId",
                table: "ums_identity_user_role",
                column: "UserId",
                principalTable: "ums_identity_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ums_identity_user_token_ums_identity_user_UserId",
                table: "ums_identity_user_token",
                column: "UserId",
                principalTable: "ums_identity_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_role_claim_ums_identity_role_RoleId",
                table: "ums_identity_role_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_user_claim_ums_identity_user_UserId",
                table: "ums_identity_user_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_user_login_ums_identity_user_UserId",
                table: "ums_identity_user_login");

            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_user_role_ums_identity_role_RoleId",
                table: "ums_identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_user_role_ums_identity_user_UserId",
                table: "ums_identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_ums_identity_user_token_ums_identity_user_UserId",
                table: "ums_identity_user_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_refresh_token",
                table: "ums_refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_user_token",
                table: "ums_identity_user_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_user_role",
                table: "ums_identity_user_role");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ums_identity_user_role_UserId_RoleId",
                table: "ums_identity_user_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_user_login",
                table: "ums_identity_user_login");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ums_identity_user_login_LoginProvider_ProviderKey",
                table: "ums_identity_user_login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_user_claim",
                table: "ums_identity_user_claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_user",
                table: "ums_identity_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_role_menu_relation",
                table: "ums_identity_role_menu_relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_role_claim",
                table: "ums_identity_role_claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_role",
                table: "ums_identity_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_ms_menu_relation",
                table: "ums_identity_ms_menu_relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_ms",
                table: "ums_identity_ms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ums_identity_menu",
                table: "ums_identity_menu");

            migrationBuilder.RenameTable(
                name: "ums_refresh_token",
                newName: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "ums_identity_user_token",
                newName: "IdentityUserToken");

            migrationBuilder.RenameTable(
                name: "ums_identity_user_role",
                newName: "IdentityUserRole");

            migrationBuilder.RenameTable(
                name: "ums_identity_user_login",
                newName: "IdentityUserLogin");

            migrationBuilder.RenameTable(
                name: "ums_identity_user_claim",
                newName: "IdentityUserClaim");

            migrationBuilder.RenameTable(
                name: "ums_identity_user",
                newName: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "ums_identity_role_menu_relation",
                newName: "IdentityRoleMenuItem");

            migrationBuilder.RenameTable(
                name: "ums_identity_role_claim",
                newName: "IdentityRoleClaim");

            migrationBuilder.RenameTable(
                name: "ums_identity_role",
                newName: "IdentityRole");

            migrationBuilder.RenameTable(
                name: "ums_identity_ms_menu_relation",
                newName: "IdentityMsMenuItem");

            migrationBuilder.RenameTable(
                name: "ums_identity_ms",
                newName: "IdentityMs");

            migrationBuilder.RenameTable(
                name: "ums_identity_menu",
                newName: "IdentityMenu");

            migrationBuilder.RenameIndex(
                name: "IX_ums_identity_user_role_RoleId",
                table: "IdentityUserRole",
                newName: "IX_IdentityUserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ums_identity_user_login_UserId",
                table: "IdentityUserLogin",
                newName: "IX_IdentityUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ums_identity_user_claim_UserId",
                table: "IdentityUserClaim",
                newName: "IX_IdentityUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ums_identity_role_claim_RoleId",
                table: "IdentityRoleClaim",
                newName: "IX_IdentityRoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserToken",
                table: "IdentityUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole",
                table: "IdentityUserRole",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IdentityUserRole_UserId_RoleId",
                table: "IdentityUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin",
                table: "IdentityUserLogin",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IdentityUserLogin_LoginProvider_ProviderKey",
                table: "IdentityUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaim",
                table: "IdentityUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRoleMenuItem",
                table: "IdentityRoleMenuItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRoleClaim",
                table: "IdentityRoleClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRole",
                table: "IdentityRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityMsMenuItem",
                table: "IdentityMsMenuItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityMs",
                table: "IdentityMs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityMenu",
                table: "IdentityMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim_IdentityRole_RoleId",
                table: "IdentityRoleClaim",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim_IdentityUser_UserId",
                table: "IdentityUserClaim",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin_IdentityUser_UserId",
                table: "IdentityUserLogin",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_RoleId",
                table: "IdentityUserRole",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_UserId",
                table: "IdentityUserRole",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken_IdentityUser_UserId",
                table: "IdentityUserToken",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
