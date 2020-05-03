using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum PayType
    {
        [Description("未支付")]
        UnPaid,
        [Description("支付宝")]
        Alipay,
        [Description("微信")]
        WeChat
    }
}
