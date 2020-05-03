using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class CouponProductCategoryRelationMap : IEntityTypeConfiguration<CouponProductCategoryRelation>
    {
        public void Configure(EntityTypeBuilder<CouponProductCategoryRelation> builder)
        {
            builder.ToTable("sms_coupon_product_category_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CouponId);
            builder.Property(c => c.ProductCategoryId);
            builder.Property(c => c.ProductCategoryName).HasMaxLength(50);
            builder.Property(c => c.ParentCategoryName).HasMaxLength(50);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
