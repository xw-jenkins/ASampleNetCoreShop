using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class CouponProductRelationMap : IEntityTypeConfiguration<CouponProductRelation>
    {
        public void Configure(EntityTypeBuilder<CouponProductRelation> builder)
        {
            builder.ToTable("sms_coupon_product_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.CouponId);
            builder.Property(c => c.ProductSn).HasMaxLength(50);
            builder.Property(c => c.ProductName).HasMaxLength(50);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
