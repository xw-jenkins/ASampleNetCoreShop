using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Members.Api.Migrations
{
    public partial class init_ums_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ums_member_level",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MsId = table.Column<string>(nullable: true),
                    GrowthPoint = table.Column<int>(nullable: false),
                    DefaultStatus = table.Column<bool>(nullable: false),
                    FreeFreightPoint = table.Column<decimal>(nullable: false),
                    CommentGrowthPoint = table.Column<int>(nullable: false),
                    PriviledgeFreeFreight = table.Column<bool>(nullable: false),
                    PriviledgeSignIn = table.Column<bool>(nullable: false),
                    PriviledgeComment = table.Column<bool>(nullable: false),
                    PriviledgePromotion = table.Column<bool>(nullable: false),
                    PriviledgeMemberPrice = table.Column<bool>(nullable: false),
                    PriviledgeBirthday = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_level", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ums_member_level");
        }
    }
}
