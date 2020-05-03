using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class OrderOperateHistoryMap : IEntityTypeConfiguration<OrderOperateHistory>
    {
        public void Configure(EntityTypeBuilder<OrderOperateHistory> builder)
        {
            builder.ToTable("oms_order_operate_history");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.OrderId);
            builder.Property(c => c.OperateUser).HasMaxLength(50);
            builder.Property(c => c.OrderStatus);
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
