using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductAttributeMap : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("pms_product_attribute");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.ProductAttributeCategoryId);
            builder.Property(c => c.SelectType);
            builder.Property(c => c.InputType);
            builder.Property(c => c.FilterType);
            builder.Property(c => c.SearchType);
            builder.Property(c => c.RelatedStatus);
            builder.Property(c => c.AddHandStatus);
            builder.Property(c => c.Type);
            builder.Property(c => c.InputList).HasMaxLength(100);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
