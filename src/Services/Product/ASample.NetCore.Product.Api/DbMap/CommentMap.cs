using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("pms_comment");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.MemberNickName).HasMaxLength(50);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.Star).HasMaxLength(10);
            builder.Property(c => c.MemberIp).HasMaxLength(20);
            builder.Property(c => c.ProductAttribute).HasMaxLength(100);
            builder.Property(c => c.Content).HasMaxLength(500);
            builder.Property(c => c.Pics).HasMaxLength(1500);
            builder.Property(c => c.MemberIcon).HasMaxLength(500);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.CollectCount);
            builder.Property(c => c.ReadCount);
            builder.Property(c => c.ReplayCount);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
