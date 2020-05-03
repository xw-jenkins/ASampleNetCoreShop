using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class SubjectMap : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("cms_subject");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryId);
            builder.Property(c => c.CategoryName).HasMaxLength(50);
            builder.Property(c => c.Title).HasMaxLength(50);
            builder.Property(c => c.Pic).HasMaxLength(500);
            builder.Property(c => c.ProductCount);
            builder.Property(c => c.CollectCount);
            builder.Property(c => c.ReadCount);
            builder.Property(c => c.CommentCount);
            builder.Property(c => c.RecommendStatus);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.AlbumPics).HasMaxLength(500);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Content).HasMaxLength(200);
            builder.Property(c => c.ForwardCount);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
