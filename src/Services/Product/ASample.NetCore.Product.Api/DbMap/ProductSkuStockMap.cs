using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductSkuStockMap : IEntityTypeConfiguration<ProductSkuStock>
    {
        public void Configure(EntityTypeBuilder<ProductSkuStock> builder)
        {
            builder.ToTable("pms_product_sku_stock");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.SkuCode).HasMaxLength(50);
            builder.Property(c => c.Sp1).HasMaxLength(500);
            builder.Property(c => c.Sp2).HasMaxLength(500);
            builder.Property(c => c.Sp3).HasMaxLength(500);
            builder.Property(c => c.Pic).HasMaxLength(1500);
            builder.Property(c => c.Price);
            builder.Property(c => c.Stock);
            builder.Property(c => c.LowStock);
            builder.Property(c => c.Sale);
            builder.Property(c => c.PromotionPric);
            builder.Property(c => c.LockStock);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
