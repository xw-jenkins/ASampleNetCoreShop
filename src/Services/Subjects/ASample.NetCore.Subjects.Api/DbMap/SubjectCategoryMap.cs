using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class SubjectCategoryMap : IEntityTypeConfiguration<SubjectCategory>
    {
        public void Configure(EntityTypeBuilder<SubjectCategory> builder)
        {
            builder.ToTable("cms_subject_category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Icon).HasMaxLength(500);
            builder.Property(c => c.SubjectCount);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
