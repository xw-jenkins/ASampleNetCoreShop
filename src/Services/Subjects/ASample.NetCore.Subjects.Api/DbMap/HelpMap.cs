using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class HelpMap : IEntityTypeConfiguration<Help>
    {
        public void Configure(EntityTypeBuilder<Help> builder)
        {
            builder.ToTable("cms_help");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryId);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.ReadCount);
            builder.Property(c => c.Title).HasMaxLength(50);
            builder.Property(c => c.Icon).HasMaxLength(500);
            builder.Property(c => c.Content).HasMaxLength(500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
