using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class IntegrationChangeHistoryMap : IEntityTypeConfiguration<IntegrationChangeHistory>
    {
        public void Configure(EntityTypeBuilder<IntegrationChangeHistory> builder)
        {
            builder.ToTable("ums_integration_change_history");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.OperateMan).HasMaxLength(50);
            builder.Property(c => c.OperateNote).HasMaxLength(500);
            builder.Property(c => c.ChangeType);
            builder.Property(c => c.ChangeCount);
            builder.Property(c => c.SourceType);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
