using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class addbrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PMS_Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FirstLetter = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    FactoryStatus = table.Column<int>(nullable: false),
                    ShowStatus = table.Column<int>(nullable: false),
                    ProductCount = table.Column<int>(nullable: false),
                    ProductCommentCount = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(maxLength: 500, nullable: true),
                    BigPic = table.Column<string>(maxLength: 500, nullable: true),
                    BrandStory = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMS_Brand", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PMS_Brand");
        }
    }
}
