using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class HomeNewProductMap : IEntityTypeConfiguration<HomeNewProduct>
    {
        public void Configure(EntityTypeBuilder<HomeNewProduct> builder)
        {
            builder.ToTable("sms_home_new_product");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.RecommendStatus);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
