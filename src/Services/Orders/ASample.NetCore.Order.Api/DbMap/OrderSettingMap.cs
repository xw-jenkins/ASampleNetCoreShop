using ASample.NetCore.Order.Api.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASample.NetCore.Order.Api.DbMap
{
    public class OrderSettingMap : IEntityTypeConfiguration<OrderSetting>
    {
        public void Configure(EntityTypeBuilder<OrderSetting> builder)
        {
            builder.ToTable("oms_order_setting");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FlashOrderOvertime);
            builder.Property(c => c.NormalOrderOvertime);
            builder.Property(c => c.ConfirmOvertime);
            builder.Property(c => c.FinishOvertime);
            builder.Property(c => c.CommentOvertime);


            builder.Property(c => c.CreateTime);
            builder.Property(c => c.DeleteTime);
            builder.Property(c => c.ModifyTime);
            builder.Property(c => c.IsDeleted);
        }
    }
}
