using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Members.Api.DbMap
{
    public class MemberTaskMap : IEntityTypeConfiguration<MemberTask>
    {
        public void Configure(EntityTypeBuilder<MemberTask> builder)
        {
            builder.ToTable("ums_member_task");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(500);
            builder.Property(c => c.Growth);
            builder.Property(c => c.Intergration);
            builder.Property(c => c.TaskType);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
