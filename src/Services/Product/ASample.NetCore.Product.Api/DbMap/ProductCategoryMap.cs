using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("pms_product_category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ParentId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Level);
            builder.Property(c => c.ProductCount);
            builder.Property(c => c.ProductUnit).HasMaxLength(10);
            builder.Property(c => c.NavStatus);
            builder.Property(c => c.ProductCount);
            builder.Property(c => c.ShowStatus);
            builder.Property(c => c.Sort);
            builder.Property(c => c.Icon).HasMaxLength(50);
            builder.Property(c => c.KeyWords).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(150);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
