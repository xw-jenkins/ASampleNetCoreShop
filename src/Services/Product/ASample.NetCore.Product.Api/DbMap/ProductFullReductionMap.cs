using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductFullReductionMap : IEntityTypeConfiguration<ProductFullReduction>
    {
        public void Configure(EntityTypeBuilder<ProductFullReduction> builder)
        {
            builder.ToTable("pms_product_full_reduction");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.FullPrice);
            builder.Property(c => c.ReducePrice);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
