using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum OrderStatus
    {
        [Description("待付款")]
        Pending = 0,
        [Description("待发货")]
        ToBeDelivered = 1,
        [Description("已发货")]
        Shipped = 2,
        [Description("已完成")]
        Completed = 3,
        [Description("已关闭")]
        Closed = 4,
        [Description("无效订单")]
        InvalidOrder = 5,
    }
}
