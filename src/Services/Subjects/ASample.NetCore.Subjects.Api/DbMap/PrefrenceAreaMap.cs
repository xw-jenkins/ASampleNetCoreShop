using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Subjects.Api.DbMap
{
    public class PrefrenceAreaMap : IEntityTypeConfiguration<PrefrenceArea>
    {
        public void Configure(EntityTypeBuilder<PrefrenceArea> builder)
        {
            builder.ToTable("cms_prefrence_area");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.SubTitle).HasMaxLength(50);
            builder.Property(c => c.Pic).HasMaxLength(500);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
