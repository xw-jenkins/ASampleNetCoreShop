using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductAttributeValueMap : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.ToTable("pms_product_attribute_value");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.ProductAttributeId);
            builder.Property(c => c.Value).HasMaxLength(100);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
