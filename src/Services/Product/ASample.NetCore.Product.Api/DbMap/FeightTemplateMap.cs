using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class FeightTemplateMap : IEntityTypeConfiguration<FeightTemplate>
    {
        public void Configure(EntityTypeBuilder<FeightTemplate> builder)
        {
            builder.ToTable("pms_feight_template");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.ChargeType);
            builder.Property(c => c.FirstWeight);
            builder.Property(c => c.FirstFee);
            builder.Property(c => c.ContinueWeight);
            builder.Property(c => c.ContinueFee);
            builder.Property(c => c.Dest).HasMaxLength(500);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
