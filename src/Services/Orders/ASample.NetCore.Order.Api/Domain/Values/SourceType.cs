using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum SourceType
    {
        [Description("PC订单")]
        PCOrder,
        [Description("app订单")]
        APPOrder
    }
}
