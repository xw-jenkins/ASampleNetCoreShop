using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Product.Api.DbMap
{
    public class ProductOperateLogMap : IEntityTypeConfiguration<ProductOperateLog>
    {
        public void Configure(EntityTypeBuilder<ProductOperateLog> builder)
        {
            builder.ToTable("pms_product_operate_log");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.PriceOld);
            builder.Property(c => c.PriceNew);
            builder.Property(c => c.SalePriceOld);
            builder.Property(c => c.SalePriceNew);
            builder.Property(c => c.GiftPointNew);
            builder.Property(c => c.UseGiftPointLimitOld);
            builder.Property(c => c.UseGiftPointLimitNew);
            builder.Property(c => c.OperateUser);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
