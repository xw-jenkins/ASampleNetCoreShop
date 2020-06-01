using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Identity.Api.Migrations
{
    public partial class initIdentityDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ums_identity_menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MsId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MenuDescription = table.Column<string>(maxLength: 500, nullable: true),
                    MenuUri = table.Column<string>(maxLength: 500, nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_ms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MsName = table.Column<string>(nullable: true),
                    MsDescription = table.Column<string>(maxLength: 500, nullable: true),
                    MsDomain = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_ms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_ms_menu_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MsId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_ms_menu_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 500, nullable: true),
                    MsId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_role_menu_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_role_menu_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 500, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MsId = table.Column<Guid>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    LastLoginIp = table.Column<string>(maxLength: 50, nullable: true),
                    LoginTimes = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    UserAvatar = table.Column<string>(nullable: true),
                    UserStatus = table.Column<bool>(nullable: false),
                    UserSource = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(maxLength: 500, nullable: true),
                    RevokedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_refresh_token", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_role_claim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 50, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_role_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ums_identity_role_claim_ums_identity_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ums_identity_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_user_claim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 50, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_user_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ums_identity_user_claim_ums_identity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ums_identity_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_user_login",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 500, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 500, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LoginIp = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_user_login", x => x.Id);
                    table.UniqueConstraint("AK_ums_identity_user_login_LoginProvider_ProviderKey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_ums_identity_user_login_ums_identity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ums_identity_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_user_role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_user_role", x => x.Id);
                    table.UniqueConstraint("AK_ums_identity_user_role_UserId_RoleId", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ums_identity_user_role_ums_identity_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ums_identity_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ums_identity_user_role_ums_identity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ums_identity_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ums_identity_user_token",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 500, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_identity_user_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_ums_identity_user_token_ums_identity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ums_identity_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ums_identity_role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ums_identity_role_claim_RoleId",
                table: "ums_identity_role_claim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ums_identity_user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ums_identity_user",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ums_identity_user_claim_UserId",
                table: "ums_identity_user_claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ums_identity_user_login_UserId",
                table: "ums_identity_user_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ums_identity_user_role_RoleId",
                table: "ums_identity_user_role",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ums_identity_menu");

            migrationBuilder.DropTable(
                name: "ums_identity_ms");

            migrationBuilder.DropTable(
                name: "ums_identity_ms_menu_relation");

            migrationBuilder.DropTable(
                name: "ums_identity_role_claim");

            migrationBuilder.DropTable(
                name: "ums_identity_role_menu_relation");

            migrationBuilder.DropTable(
                name: "ums_identity_user_claim");

            migrationBuilder.DropTable(
                name: "ums_identity_user_login");

            migrationBuilder.DropTable(
                name: "ums_identity_user_role");

            migrationBuilder.DropTable(
                name: "ums_identity_user_token");

            migrationBuilder.DropTable(
                name: "ums_refresh_token");

            migrationBuilder.DropTable(
                name: "ums_identity_role");

            migrationBuilder.DropTable(
                name: "ums_identity_user");
        }
    }
}
