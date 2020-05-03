using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class IntegrationConsumeSettingMap : IEntityTypeConfiguration<IntegrationConsumeSetting>
    {
        public void Configure(EntityTypeBuilder<IntegrationConsumeSetting> builder)
        {
            builder.ToTable("ums_integration_consume_setting");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DeductionPerAmount);
            builder.Property(c => c.MaxPercentPerOrder);
            builder.Property(c => c.UseUnit);
            builder.Property(c => c.CouponStatus);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
