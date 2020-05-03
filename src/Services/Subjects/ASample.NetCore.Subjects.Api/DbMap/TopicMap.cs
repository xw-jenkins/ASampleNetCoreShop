using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("cms_topic");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.StartTime);
            builder.Property(c => c.EndTime);
            builder.Property(c => c.AttendCount);
            builder.Property(c => c.AttentionCount);
            builder.Property(c => c.ReadCount);
            builder.Property(c => c.AwardName).HasMaxLength(50);
            builder.Property(c => c.AttendType).HasMaxLength(500);
            builder.Property(c => c.Content).HasMaxLength(200);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
