using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Marketing.Api.DbMap
{
    public class HomeBrandMap : IEntityTypeConfiguration<HomeBrand>
    {
        public void Configure(EntityTypeBuilder<HomeBrand> builder)
        {
            builder.ToTable("sms_home_brand");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.BrandName).HasMaxLength(50);
            builder.Property(c => c.BrandId);
            builder.Property(c => c.RecommendStatus);
            builder.Property(c => c.Sort);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
