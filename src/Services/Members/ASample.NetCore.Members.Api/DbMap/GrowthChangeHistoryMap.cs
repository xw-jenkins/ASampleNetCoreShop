using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class GrowthChangeHistoryMap : IEntityTypeConfiguration<GrowthChangeHistory>
    {
        public void Configure(EntityTypeBuilder<GrowthChangeHistory> builder)
        {
            builder.ToTable("ums_growth_change_history");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.OperateMan).HasMaxLength(50);
            builder.Property(c => c.OperateNote).HasMaxLength(500);
            builder.Property(c => c.ChangeType);
            builder.Property(c => c.ChangeCount);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
