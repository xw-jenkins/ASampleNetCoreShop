using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("pms_brand");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.FirstLetter).HasMaxLength(50);
            builder.Property(c => c.BrandStory).HasMaxLength(50);
            builder.Property(c => c.BigPic).HasMaxLength(500);
            builder.Property(c => c.Logo).HasMaxLength(500);
            builder.Property(c => c.FactoryStatus);
            builder.Property(c => c.ProductCount);
            builder.Property(c => c.ProductCommentCount);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
