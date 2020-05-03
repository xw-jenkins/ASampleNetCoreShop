using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Marketing.Api.Migrations
{
    public partial class init_SMS_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sms_coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CouponType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    PlatformType = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PerLimit = table.Column<int>(nullable: false),
                    MinPoint = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    UseType = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    PublishCount = table.Column<int>(nullable: false),
                    UseCcount = table.Column<int>(nullable: false),
                    ReceiveCount = table.Column<int>(nullable: false),
                    EnableTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    MemberLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_coupon_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CouponId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    OrderSn = table.Column<string>(maxLength: 50, nullable: true),
                    CouponCode = table.Column<string>(maxLength: 50, nullable: true),
                    MemberNickName = table.Column<string>(maxLength: 50, nullable: true),
                    GetCouponType = table.Column<int>(nullable: false),
                    UseStatus = table.Column<int>(nullable: false),
                    UseTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_coupon_history", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_coupon_product_category_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CouponId = table.Column<Guid>(nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: false),
                    ProductCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    ParentCategoryName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_coupon_product_category_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_coupon_product_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CouponId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    ProductSn = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_coupon_product_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_flash_promotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_flash_promotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_flash_promotion_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    MemberPhone = table.Column<string>(maxLength: 20, nullable: true),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    SubscribeTime = table.Column<DateTime>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_flash_promotion_log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_flash_promotion_product_relation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    FlashPromotionId = table.Column<Guid>(nullable: false),
                    FlashPromotionSessionId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    FlashPromotionPrice = table.Column<decimal>(nullable: false),
                    FlashPromotionCount = table.Column<int>(nullable: false),
                    FlashPromotionLimit = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_flash_promotion_product_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_flash_promotion_session",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_flash_promotion_session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_home_advertise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Pic = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ClickCount = table.Column<string>(nullable: true),
                    OrderCount = table.Column<string>(nullable: true),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    Note = table.Column<string>(maxLength: 250, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_home_advertise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_home_brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false),
                    BrandName = table.Column<string>(maxLength: 50, nullable: true),
                    RecommendStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_home_brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_home_new_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    RecommendStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_home_new_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_home_recommend_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    RecommendStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_home_recommend_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sms_home_recommend_subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    SubjectName = table.Column<string>(maxLength: 50, nullable: true),
                    RecommendStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_home_recommend_subject", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sms_coupon");

            migrationBuilder.DropTable(
                name: "sms_coupon_history");

            migrationBuilder.DropTable(
                name: "sms_coupon_product_category_relation");

            migrationBuilder.DropTable(
                name: "sms_coupon_product_relation");

            migrationBuilder.DropTable(
                name: "sms_flash_promotion");

            migrationBuilder.DropTable(
                name: "sms_flash_promotion_log");

            migrationBuilder.DropTable(
                name: "sms_flash_promotion_product_relation");

            migrationBuilder.DropTable(
                name: "sms_flash_promotion_session");

            migrationBuilder.DropTable(
                name: "sms_home_advertise");

            migrationBuilder.DropTable(
                name: "sms_home_brand");

            migrationBuilder.DropTable(
                name: "sms_home_new_product");

            migrationBuilder.DropTable(
                name: "sms_home_recommend_product");

            migrationBuilder.DropTable(
                name: "sms_home_recommend_subject");
        }
    }
}
