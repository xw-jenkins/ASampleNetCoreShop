using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberRuleSettingMap : IEntityTypeConfiguration<MemberRuleSetting>
    {
        public void Configure(EntityTypeBuilder<MemberRuleSetting> builder)
        {
            builder.ToTable("ums_member_rule_setting");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ContinueSignDay);
            builder.Property(c => c.ContinueSignPoint);
            builder.Property(c => c.ConsumePerPoint);
            builder.Property(c => c.LowOrderAmount);
            builder.Property(c => c.MaxPointPerOrder);
            builder.Property(c => c.Type);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
