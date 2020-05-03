using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductVerifyRecordMap : IEntityTypeConfiguration<ProductVerifyRecord>
    {
        public void Configure(EntityTypeBuilder<ProductVerifyRecord> builder)
        {
            builder.ToTable("pms_product_verify_record");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.VerifyMan);
            builder.Property(c => c.Detail).HasMaxLength(500);
            builder.Property(c => c.Status);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
