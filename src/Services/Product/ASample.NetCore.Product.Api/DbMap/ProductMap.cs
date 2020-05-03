using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("pms_product");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.BrandId);
            builder.Property(c => c.ProductCategoryId);
            builder.Property(c => c.FeightTemplateId);
            builder.Property(c => c.ProductAttributeCategoryId);
            builder.Property(c => c.BrandName).HasMaxLength(50);
            builder.Property(c => c.SubTitle).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(50);
            builder.Property(c => c.ProductSN).HasMaxLength(50);
            builder.Property(c => c.ProductCategoryName).HasMaxLength(50);
            builder.Property(c => c.Price);
            builder.Property(c => c.OriginalPrice);
            builder.Property(c => c.Stock);
            builder.Property(c => c.LowStock);
            builder.Property(c => c.Unit);
            builder.Property(c => c.Weight);
            builder.Property(c => c.Sort);
            builder.Property(c => c.GiftGrowth);
            builder.Property(c => c.GiftPoint);
            builder.Property(c => c.UsePointLimit);
            builder.Property(c => c.PreviewStatus);
            builder.Property(c => c.PublishStatus);
            builder.Property(c => c.Sale);
            builder.Property(c => c.NewStatus);
            builder.Property(c => c.RecommendStatus);
            builder.Property(c => c.DeleteStatus);
            builder.Property(c => c.VerifyStatus);
            builder.Property(c => c.Pic).HasMaxLength(500);
            builder.Property(c => c.AlbumPics).HasMaxLength(2500);
            builder.Property(c => c.PromotionPrice);
            builder.Property(c => c.ServiceIds).HasMaxLength(500);
            builder.Property(c => c.KeyWords).HasMaxLength(50);
            builder.Property(c => c.Note).HasMaxLength(50);
            builder.Property(c => c.DetailTitle).HasMaxLength(50);
            builder.Property(c => c.DetailDesc).HasMaxLength(350);
            builder.Property(c => c.DetailHtml).HasMaxLength(2500);
            builder.Property(c => c.DetailMobileHtml).HasMaxLength(2500);
            builder.Property(c => c.PromotionStartTime);
            builder.Property(c => c.PromotionEndTime);
            builder.Property(c => c.PromotionPerLimit);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
