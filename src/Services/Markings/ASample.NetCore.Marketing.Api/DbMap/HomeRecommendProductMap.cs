using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class HomeRecommendProductMap : IEntityTypeConfiguration<HomeRecommendProduct>
    {
        public void Configure(EntityTypeBuilder<HomeRecommendProduct> builder)
        {
            builder.ToTable("sms_home_recommend_product");
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
