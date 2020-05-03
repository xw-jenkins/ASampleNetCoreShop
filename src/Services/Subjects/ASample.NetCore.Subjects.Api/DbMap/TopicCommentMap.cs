using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class TopicCommentMap : IEntityTypeConfiguration<TopicComment>
    {
        public void Configure(EntityTypeBuilder<TopicComment> builder)
        {
            builder.ToTable("cms_topic_comment");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TopicId);
            builder.Property(c => c.MemberNickName).HasMaxLength(50);
            builder.Property(c => c.MemberIcon).HasMaxLength(50);
            builder.Property(c => c.Content).HasMaxLength(500);
            builder.Property(c => c.ShowStatus);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
