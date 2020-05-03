using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductMemberPriceMap : IEntityTypeConfiguration<ProductMemberPrice>
    {
        public void Configure(EntityTypeBuilder<ProductMemberPrice> builder)
        {
            builder.ToTable("pms_product_member_price");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.MemberLevelId);
            builder.Property(c => c.MemberLevelName).HasMaxLength(50);
            builder.Property(c => c.Price);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
