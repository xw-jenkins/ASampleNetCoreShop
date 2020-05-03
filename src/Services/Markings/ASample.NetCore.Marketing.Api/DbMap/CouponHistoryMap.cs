using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class CouponHistoryMap : IEntityTypeConfiguration<CouponHistory>
    {
        public void Configure(EntityTypeBuilder<CouponHistory> builder)
        {
            builder.ToTable("sms_coupon_history");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CouponId);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.OrderId);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.OrderSn).HasMaxLength(50);
            builder.Property(c => c.CouponCode).HasMaxLength(50);
            builder.Property(c => c.MemberNickName).HasMaxLength(50);
            builder.Property(c => c.GetCouponType);
            builder.Property(c => c.UseStatus);
            builder.Property(c => c.UseTime);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
