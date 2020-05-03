using ASample.NetCore.Product.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductCategoryAttributeRelationMap : IEntityTypeConfiguration<ProductCategoryAttributeRelation>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryAttributeRelation> builder)
        {
            builder.ToTable("pms_product_category_attribute_relaation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductCategoryId);
            builder.Property(c => c.ProductAttributeId);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
