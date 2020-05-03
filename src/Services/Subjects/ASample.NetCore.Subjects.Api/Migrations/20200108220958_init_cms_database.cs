using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Subjects.Api.Migrations
{
    public partial class init_cms_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_help",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Icon = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ShowStatus = table.Column<bool>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_help", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_help_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Icon = table.Column<string>(maxLength: 500, nullable: true),
                    HelpCount = table.Column<int>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_help_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_member_report",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ReportType = table.Column<int>(nullable: false),
                    ReportMemberName = table.Column<string>(maxLength: 50, nullable: true),
                    ReportObject = table.Column<string>(maxLength: 200, nullable: true),
                    ReportStatus = table.Column<int>(nullable: false),
                    HandleStatus = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_member_report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_prefrence_area",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(maxLength: 50, nullable: true),
                    Pic = table.Column<string>(maxLength: 500, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_prefrence_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_prefrence_area_product_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    PrefrenceAreaId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_prefrence_area_product_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Pic = table.Column<string>(maxLength: 500, nullable: true),
                    ProductCount = table.Column<int>(nullable: false),
                    CollectCount = table.Column<int>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    RecommendStatus = table.Column<bool>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false),
                    AlbumPics = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    ForwardCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_subject_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Icon = table.Column<string>(maxLength: 500, nullable: true),
                    SubjectCount = table.Column<int>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_subject_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_subject_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    MemberNickName = table.Column<string>(maxLength: 50, nullable: true),
                    MemberIcon = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    ShowStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_subject_comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_subject_product_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_subject_product_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    AttendCount = table.Column<int>(nullable: false),
                    AttentionCount = table.Column<int>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    AwardName = table.Column<string>(maxLength: 50, nullable: true),
                    AttendType = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_topic_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Icon = table.Column<string>(maxLength: 500, nullable: true),
                    SubjectCount = table.Column<int>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_topic_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cms_topic_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    TopicId = table.Column<Guid>(nullable: false),
                    MemberNickName = table.Column<string>(maxLength: 50, nullable: true),
                    MemberIcon = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    ShowStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_topic_comment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cms_help");

            migrationBuilder.DropTable(
                name: "cms_help_category");

            migrationBuilder.DropTable(
                name: "cms_member_report");

            migrationBuilder.DropTable(
                name: "cms_prefrence_area");

            migrationBuilder.DropTable(
                name: "cms_prefrence_area_product_relation");

            migrationBuilder.DropTable(
                name: "cms_subject");

            migrationBuilder.DropTable(
                name: "cms_subject_category");

            migrationBuilder.DropTable(
                name: "cms_subject_comment");

            migrationBuilder.DropTable(
                name: "cms_subject_product_relation");

            migrationBuilder.DropTable(
                name: "cms_topic");

            migrationBuilder.DropTable(
                name: "cms_topic_category");

            migrationBuilder.DropTable(
                name: "cms_topic_comment");
        }
    }
}
