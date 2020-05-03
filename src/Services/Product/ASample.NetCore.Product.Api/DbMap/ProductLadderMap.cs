using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductLadderMap : IEntityTypeConfiguration<ProductLadder>
    {
        public void Configure(EntityTypeBuilder<ProductLadder> builder)
        {
            builder.ToTable("pms_product_ladder");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.Count);
            builder.Property(c => c.Discount);
            builder.Property(c => c.Price);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
