using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum OrderType
    {
        [Description("正常订单")]
        NormalOrder = 0,
        [Description("秒杀订单")]
        SpikeOrder = 1,
    }
}
