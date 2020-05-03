using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASample.NetCore.Product.Api.Migrations
{
    public partial class init_product_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PMS_Brand",
                table: "PMS_Brand");

            migrationBuilder.RenameTable(
                name: "PMS_Brand",
                newName: "pms_brand");

            migrationBuilder.AlterColumn<bool>(
                name: "ShowStatus",
                table: "pms_brand",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "pms_brand",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstLetter",
                table: "pms_brand",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "FactoryStatus",
                table: "pms_brand",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pms_brand",
                table: "pms_brand",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "pms_album",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ConverPic = table.Column<string>(nullable: true),
                    PicCount = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Decription = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_album_pic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    AlbumId = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_album_pic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    MemberNickName = table.Column<string>(maxLength: 50, nullable: true),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    Star = table.Column<string>(maxLength: 10, nullable: true),
                    MemberIp = table.Column<string>(maxLength: 20, nullable: true),
                    ShowStatus = table.Column<bool>(nullable: false),
                    ProductAttribute = table.Column<string>(maxLength: 100, nullable: true),
                    CollectCount = table.Column<int>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    Pics = table.Column<string>(maxLength: 1500, nullable: true),
                    MemberIcon = table.Column<string>(maxLength: 500, nullable: true),
                    ReplayCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_comment_replay",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CommentId = table.Column<Guid>(nullable: false),
                    MemberNickName = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    MemberIcon = table.Column<string>(maxLength: 500, nullable: true),
                    ReplayType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_comment_replay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_feight_template",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ChargeType = table.Column<int>(nullable: false),
                    FirstWeight = table.Column<decimal>(nullable: false),
                    FirstFee = table.Column<decimal>(nullable: false),
                    ContinueWeight = table.Column<decimal>(nullable: false),
                    ContinueFee = table.Column<decimal>(nullable: false),
                    Dest = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_feight_template", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_member_price",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductUniqueId = table.Column<Guid>(nullable: false),
                    MemberLevelId = table.Column<Guid>(nullable: false),
                    MemberLevelName = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_member_price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false),
                    BrandName = table.Column<string>(maxLength: 50, nullable: true),
                    ProductCategoryId = table.Column<Guid>(nullable: false),
                    ProductCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    FeightTemplateId = table.Column<Guid>(nullable: false),
                    ProductAttributeCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    ProductSN = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    GiftGrowth = table.Column<bool>(nullable: false),
                    GiftPoint = table.Column<bool>(nullable: false),
                    UsePointLimit = table.Column<bool>(nullable: false),
                    PreviewStatus = table.Column<bool>(nullable: false),
                    PublicStatus = table.Column<bool>(nullable: false),
                    Sale = table.Column<bool>(nullable: false),
                    NewStatus = table.Column<bool>(nullable: false),
                    RecommandStatus = table.Column<bool>(nullable: false),
                    Pic = table.Column<string>(maxLength: 500, nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    VerifyStatus = table.Column<bool>(nullable: false),
                    PromotionPrice = table.Column<decimal>(nullable: false),
                    LowStock = table.Column<int>(nullable: false),
                    ServicesIds = table.Column<string>(maxLength: 500, nullable: true),
                    KeyWords = table.Column<string>(maxLength: 50, nullable: true),
                    Note = table.Column<string>(maxLength: 50, nullable: true),
                    AlbumPics = table.Column<string>(maxLength: 500, nullable: true),
                    DetailTitle = table.Column<string>(maxLength: 50, nullable: true),
                    DetailDesc = table.Column<string>(maxLength: 350, nullable: true),
                    DetailHtml = table.Column<string>(maxLength: 2500, nullable: true),
                    DetailMobile_Html = table.Column<string>(maxLength: 2500, nullable: true),
                    PromotionStartTime = table.Column<DateTime>(nullable: true),
                    PromotionEndTime = table.Column<DateTime>(nullable: true),
                    PromotionPerLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductAttributeCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SelectType = table.Column<int>(nullable: false),
                    InputType = table.Column<int>(nullable: false),
                    InputList = table.Column<string>(maxLength: 100, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    FilterType = table.Column<int>(nullable: false),
                    SearchType = table.Column<int>(nullable: false),
                    RelatedStatus = table.Column<int>(nullable: false),
                    AddHandStatus = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_attribute_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    AttributeCount = table.Column<int>(nullable: false),
                    ParamCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_attribute_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_attribute_value",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_attribute_value", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ProductCount = table.Column<int>(nullable: false),
                    ProductUnit = table.Column<string>(maxLength: 10, nullable: true),
                    NavStatus = table.Column<bool>(nullable: false),
                    ShowStatus = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    KeyWords = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_category_attribute_relaation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductCategoryId = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_category_attribute_relaation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_ladder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_ladder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_operate_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    PriceOld = table.Column<decimal>(nullable: false),
                    PriceNew = table.Column<decimal>(nullable: false),
                    SalePriceOld = table.Column<decimal>(nullable: false),
                    SalePriceNew = table.Column<decimal>(nullable: false),
                    GiftPointOld = table.Column<decimal>(nullable: false),
                    GiftPointNew = table.Column<decimal>(nullable: false),
                    UseGiftPointLimitOld = table.Column<decimal>(nullable: false),
                    UseGiftPointLimitNew = table.Column<decimal>(nullable: false),
                    OperateUser = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_operate_log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_sku_stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    SkuCode = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    LowStock = table.Column<int>(nullable: false),
                    Sp1 = table.Column<string>(maxLength: 500, nullable: true),
                    Sp2 = table.Column<string>(maxLength: 500, nullable: true),
                    Sp3 = table.Column<string>(maxLength: 500, nullable: true),
                    Pic = table.Column<string>(maxLength: 1500, nullable: true),
                    Sale = table.Column<int>(nullable: false),
                    PromotionPric = table.Column<decimal>(nullable: false),
                    LockStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_sku_stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_verify_record",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    VerifyMan = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_verify_record", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pms_album");

            migrationBuilder.DropTable(
                name: "pms_album_pic");

            migrationBuilder.DropTable(
                name: "pms_comment");

            migrationBuilder.DropTable(
                name: "pms_comment_replay");

            migrationBuilder.DropTable(
                name: "pms_feight_template");

            migrationBuilder.DropTable(
                name: "pms_member_price");

            migrationBuilder.DropTable(
                name: "pms_product");

            migrationBuilder.DropTable(
                name: "pms_product_attribute");

            migrationBuilder.DropTable(
                name: "pms_product_attribute_category");

            migrationBuilder.DropTable(
                name: "pms_product_attribute_value");

            migrationBuilder.DropTable(
                name: "pms_product_category");

            migrationBuilder.DropTable(
                name: "pms_product_category_attribute_relaation");

            migrationBuilder.DropTable(
                name: "pms_product_ladder");

            migrationBuilder.DropTable(
                name: "pms_product_operate_log");

            migrationBuilder.DropTable(
                name: "pms_product_sku_stock");

            migrationBuilder.DropTable(
                name: "pms_product_verify_record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pms_brand",
                table: "pms_brand");

            migrationBuilder.RenameTable(
                name: "pms_brand",
                newName: "PMS_Brand");

            migrationBuilder.AlterColumn<int>(
                name: "ShowStatus",
                table: "PMS_Brand",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PMS_Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstLetter",
                table: "PMS_Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryStatus",
                table: "PMS_Brand",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PMS_Brand",
                table: "PMS_Brand",
                column: "Id");
        }
    }
}
