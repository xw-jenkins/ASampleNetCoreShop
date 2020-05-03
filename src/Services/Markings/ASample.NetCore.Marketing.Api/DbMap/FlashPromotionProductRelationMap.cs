using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class FlashPromotionProductRelationMap : IEntityTypeConfiguration<FlashPromotionProductRelation>
    {
        public void Configure(EntityTypeBuilder<FlashPromotionProductRelation> builder)
        {
            builder.ToTable("sms_flash_promotion_product_relation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.FlashPromotionId);
            builder.Property(c => c.FlashPromotionSessionId);
            builder.Property(c => c.FlashPromotionPrice);
            builder.Property(c => c.FlashPromotionCount);
            builder.Property(c => c.FlashPromotionLimit);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
