using Microsoft.EntityFrameworkCore;
using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class OrderMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("oms_order");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.MemberId);
            builder.Property(c => c.CouponId);
            builder.Property(c => c.OrderSn).HasMaxLength(50);
            builder.Property(c => c.MemberUserName).HasMaxLength(50);
            builder.Property(c => c.TotalAmount);
            builder.Property(c => c.PayAmount);
            builder.Property(c => c.FreightAmount);
            builder.Property(c => c.PromotionAmount);
            builder.Property(c => c.IntegrationAmount);
            builder.Property(c => c.CouponAmount);
            builder.Property(c => c.DiscountAmount);
            builder.Property(c => c.PayType);
            builder.Property(c => c.SourceType);
            builder.Property(c => c.Status);
            builder.Property(c => c.OrderType);
            builder.Property(c => c.AutoConfirmDay);
            builder.Property(c => c.Integration);
            builder.Property(c => c.Growth);
            builder.Property(c => c.BillType);
            builder.Property(c => c.DeliveryCompany).HasMaxLength(500);
            builder.Property(c => c.DeliverySn).HasMaxLength(50);
            builder.Property(c => c.BillHeader).HasMaxLength(50);
            builder.Property(c => c.PromotionInfo).HasMaxLength(500);
            builder.Property(c => c.BillContent).HasMaxLength(500);
            builder.Property(c => c.BillReceiverPhone).HasMaxLength(20);
            builder.Property(c => c.BillReceiverEmail).HasMaxLength(50);
            builder.Property(c => c.ReceiverName).HasMaxLength(20);
            builder.Property(c => c.ReceiverPhone).HasMaxLength(20);
            builder.Property(c => c.ReceiverPostCode).HasMaxLength(20);
            builder.Property(c => c.ReceiverProvince).HasMaxLength(50);
            builder.Property(c => c.ReceiverCity).HasMaxLength(20);
            builder.Property(c => c.ReceiverRegion).HasMaxLength(20);
            builder.Property(c => c.ReceiverDetailAddress).HasMaxLength(100);
            builder.Property(c => c.Note).HasMaxLength(100);
            builder.Property(c => c.ConfirmStatus);
            builder.Property(c => c.DeleteStatus);
            builder.Property(c => c.UseIntegration);


            builder.Property(c => c.PaymentTime);
            builder.Property(c => c.DeliveryTime);
            builder.Property(c => c.ReceiveTime);
            builder.Property(c => c.CommentTime);
            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
