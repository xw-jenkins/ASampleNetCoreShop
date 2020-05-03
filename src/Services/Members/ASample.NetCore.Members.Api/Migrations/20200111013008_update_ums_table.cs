using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Members.Api.Migrations
{
    public partial class update_ums_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ums_growth_change_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ChangeType = table.Column<int>(nullable: false),
                    ChangeCount = table.Column<int>(nullable: false),
                    OperateMan = table.Column<string>(maxLength: 50, nullable: true),
                    OperateNote = table.Column<string>(maxLength: 500, nullable: true),
                    SourceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_growth_change_history", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_integration_change_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ChangeType = table.Column<int>(nullable: false),
                    ChangeCount = table.Column<int>(nullable: false),
                    OperateMan = table.Column<string>(maxLength: 50, nullable: true),
                    OperateNote = table.Column<string>(maxLength: 500, nullable: true),
                    SourceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_integration_change_history", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_integration_consume_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    DeductionPerAmount = table.Column<int>(nullable: false),
                    MaxPercentPerOrder = table.Column<int>(nullable: false),
                    UseUnit = table.Column<int>(nullable: false),
                    CouponStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_integration_consume_setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberLevelId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 500, nullable: true),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(maxLength: 20, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    Job = table.Column<string>(maxLength: 20, nullable: true),
                    PersonalizedSignature = table.Column<string>(maxLength: 200, nullable: true),
                    SourceType = table.Column<string>(nullable: true),
                    Integration = table.Column<int>(nullable: false),
                    Growth = table.Column<int>(nullable: false),
                    LuckeyCount = table.Column<int>(nullable: false),
                    HistoryIntegration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_login_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    Ip = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    LoginType = table.Column<int>(nullable: false),
                    Province = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_login_log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_member_tag_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_member_tag_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_product_category_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_product_category_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_receive_address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    DefaultStatus = table.Column<bool>(nullable: false),
                    PostCode = table.Column<string>(maxLength: 20, nullable: true),
                    Province = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    Region = table.Column<string>(maxLength: 20, nullable: true),
                    DetailAddress = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_receive_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_rule_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ContinueSignDay = table.Column<int>(nullable: false),
                    ContinueSignPoint = table.Column<int>(nullable: false),
                    ConsumePerPoint = table.Column<decimal>(nullable: false),
                    LowOrderAmount = table.Column<decimal>(nullable: false),
                    MaxPointPerOrder = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_rule_setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_statistics_info",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ConsumeAmount = table.Column<decimal>(nullable: false),
                    OrderCount = table.Column<int>(nullable: false),
                    CouponCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    ReturnOrderCount = table.Column<int>(nullable: false),
                    LoginCount = table.Column<int>(nullable: false),
                    AttendCount = table.Column<int>(nullable: false),
                    FansCount = table.Column<int>(nullable: false),
                    CollectProductCount = table.Column<int>(nullable: false),
                    CollectSubjectCount = table.Column<int>(nullable: false),
                    CollectTopicCount = table.Column<int>(nullable: false),
                    CollectCommentCount = table.Column<int>(nullable: false),
                    InviteFriendCount = table.Column<int>(nullable: false),
                    RecentOrderTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_statistics_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    FinishOrderCount = table.Column<int>(nullable: false),
                    FinishOrderAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ums_member_task",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Growth = table.Column<int>(nullable: false),
                    Intergration = table.Column<int>(nullable: false),
                    TaskType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ums_member_task", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ums_growth_change_history");

            migrationBuilder.DropTable(
                name: "ums_integration_change_history");

            migrationBuilder.DropTable(
                name: "ums_integration_consume_setting");

            migrationBuilder.DropTable(
                name: "ums_member");

            migrationBuilder.DropTable(
                name: "ums_member_login_log");

            migrationBuilder.DropTable(
                name: "ums_member_member_tag_relation");

            migrationBuilder.DropTable(
                name: "ums_member_product_category_relation");

            migrationBuilder.DropTable(
                name: "ums_member_receive_address");

            migrationBuilder.DropTable(
                name: "ums_member_rule_setting");

            migrationBuilder.DropTable(
                name: "ums_member_statistics_info");

            migrationBuilder.DropTable(
                name: "ums_member_tag");

            migrationBuilder.DropTable(
                name: "ums_member_task");
        }
    }
}
