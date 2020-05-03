using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("oms_cart_item");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.ProductSkuId);
            builder.Property(c => c.ProductCategoryId);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.ProductSkuCode).HasMaxLength(50);
            builder.Property(c => c.ProductSn).HasMaxLength(50);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.ProductSubTitle).HasMaxLength(500);
            builder.Property(c => c.ProductBrand).HasMaxLength(50);
            builder.Property(c => c.ProductPic).HasMaxLength(500);
            builder.Property(c => c.MemberNickName).HasMaxLength(50);
            builder.Property(c => c.Quantity);
            builder.Property(c => c.Price);
            builder.Property(c => c.DeleteStatus);
            builder.Property(c => c.Sp1).HasMaxLength(50);
            builder.Property(c => c.Sp2).HasMaxLength(50);
            builder.Property(c => c.Sp3).HasMaxLength(50);
            builder.Property(c => c.ProductAttr).HasMaxLength(5000);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
