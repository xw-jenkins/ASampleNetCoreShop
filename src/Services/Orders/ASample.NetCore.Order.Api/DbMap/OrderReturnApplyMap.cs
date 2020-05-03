using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class OrderReturnApplyMap : IEntityTypeConfiguration<OrderReturnApply>
    {
        public void Configure(EntityTypeBuilder<OrderReturnApply> builder)
        {
            builder.ToTable("oms_order_return_apply");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.OrderId);
            builder.Property(c => c.CompanyAddressId);
            builder.Property(c => c.OrderSn).HasMaxLength(50);
            builder.Property(c => c.MemberUserName).HasMaxLength(50);
            builder.Property(c => c.ProductName).HasMaxLength(50);
            builder.Property(c => c.ProductBrand).HasMaxLength(50);
            builder.Property(c => c.ProductPic).HasMaxLength(500);
            builder.Property(c => c.ProductAttr).HasMaxLength(5000);
            builder.Property(c => c.ProductCount);
            builder.Property(c => c.ProductPrice);
            builder.Property(c => c.ProductRealPrice);

            builder.Property(c => c.ReturnName).HasMaxLength(50);
            builder.Property(c => c.ReturnPhone).HasMaxLength(20);
            builder.Property(c => c.ReturnAmount);
            builder.Property(c => c.Status);
            builder.Property(c => c.Reason).HasMaxLength(500);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.ProofPics).HasMaxLength(2500);
            builder.Property(c => c.HandleNote).HasMaxLength(500);
            builder.Property(c => c.HandleMan).HasMaxLength(50);
            builder.Property(c => c.ReceiveMan).HasMaxLength(50);
            builder.Property(c => c.ReceiveNote).HasMaxLength(250);


            builder.Property(c => c.HandleTime);
            builder.Property(c => c.ReceiveTime);
            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
