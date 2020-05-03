using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class CommentReplayMap : IEntityTypeConfiguration<CommentReplay>
    {
        public void Configure(EntityTypeBuilder<CommentReplay> builder)
        {
            builder.ToTable("pms_comment_replay");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CommentId);
            builder.Property(c => c.MemberNickName).HasMaxLength(50);
            builder.Property(c => c.Content).HasMaxLength(500);
            builder.Property(c => c.MemberIcon).HasMaxLength(500);
            builder.Property(c => c.ReplayType);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
