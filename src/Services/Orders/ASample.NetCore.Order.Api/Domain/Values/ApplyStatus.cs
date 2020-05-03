using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum ApplyStatus
    {
        [Description("待处理")]
        Pending,
        [Description("退货中")]
        Returning,
        [Description("已完成")]
        Completed,
        [Description("已拒绝")]
        Rejected
    }
}
