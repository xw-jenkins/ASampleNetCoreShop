using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductAttributeCategoryMap : IEntityTypeConfiguration<ProductAttributeCategory>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeCategory> builder)
        {
            builder.ToTable("pms_product_attribute_category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.AttributeCount);
            builder.Property(c => c.ParamCount);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
