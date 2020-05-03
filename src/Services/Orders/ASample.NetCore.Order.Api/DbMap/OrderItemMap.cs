using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("oms_order_item");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.OrderId);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.ProductSkuId);
            builder.Property(c => c.ProductCategoryId);
            builder.Property(c => c.ProductSkuCode).HasMaxLength(50);
            builder.Property(c => c.OrderSn).HasMaxLength(50);
            builder.Property(c => c.ProductSn).HasMaxLength(50);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.ProductBrand).HasMaxLength(50);
            builder.Property(c => c.ProductPic).HasMaxLength(500);
            builder.Property(c => c.ProductPrice);
            builder.Property(c => c.ProductQuantity);
            builder.Property(c => c.Sp1).HasMaxLength(50);
            builder.Property(c => c.Sp2).HasMaxLength(50);
            builder.Property(c => c.Sp3).HasMaxLength(50);
            builder.Property(c => c.PromotionName).HasMaxLength(50);
            builder.Property(c => c.PromotionAmount);
            builder.Property(c => c.IntegrationAmount);
            builder.Property(c => c.CouponAmount);
            builder.Property(c => c.RealAmount);
            builder.Property(c => c.GiftIntegration);
            builder.Property(c => c.GiftGrowth);
            builder.Property(c => c.ProductAttr).HasMaxLength(5000);

            
            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
