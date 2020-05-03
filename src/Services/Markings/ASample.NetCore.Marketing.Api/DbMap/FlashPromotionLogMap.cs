using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class FlashPromotionLogMap : IEntityTypeConfiguration<FlashPromotionLog>
    {
        public void Configure(EntityTypeBuilder<FlashPromotionLog> builder)
        {
            builder.ToTable("sms_flash_promotion_log");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.MemberPhone).HasMaxLength(20);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.SubscribeTime);
            builder.Property(c => c.SendTime);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
