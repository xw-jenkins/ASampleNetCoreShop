using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class CouponMap : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("sms_coupon");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.CouponType);
            builder.Property(c => c.PlatformType);
            builder.Property(c => c.Count);
            builder.Property(c => c.Amount);
            builder.Property(c => c.PerLimit);
            builder.Property(c => c.MinPoint);
            builder.Property(c => c.StartTime);
            builder.Property(c => c.EndTime);
            builder.Property(c => c.UseType);
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.Property(c => c.PublishCount);
            builder.Property(c => c.UseCcount);
            builder.Property(c => c.ReceiveCount);
            builder.Property(c => c.EnableTime);
            builder.Property(c => c.Code).HasMaxLength(50);
            builder.Property(c => c.MemberLevel);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
