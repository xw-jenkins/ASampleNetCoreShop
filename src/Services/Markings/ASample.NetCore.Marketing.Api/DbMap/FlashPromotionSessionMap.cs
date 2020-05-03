using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class FlashPromotionSessionMap : IEntityTypeConfiguration<FlashPromotionSession>
    {
        public void Configure(EntityTypeBuilder<FlashPromotionSession> builder)
        {
            builder.ToTable("sms_flash_promotion_session");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FlashPromotionId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.StartTime);
            builder.Property(c => c.EndTime);
            builder.Property(c => c.Status);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
