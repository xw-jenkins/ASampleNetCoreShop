using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class FlashPromotionMap : IEntityTypeConfiguration<FlashPromotion>
    {
        public void Configure(EntityTypeBuilder<FlashPromotion> builder)
        {
            builder.ToTable("sms_flash_promotion");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(50);
            builder.Property(c => c.StartDate);
            builder.Property(c => c.EndDate);
            builder.Property(c => c.Status);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
