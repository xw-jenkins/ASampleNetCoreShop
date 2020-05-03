
using System.ComponentModel;

namespace ASample.NetCore.Product.Api.Domain.Values
{
    public enum StatusType
    {
        [Description("不可用")]
        Enable = 1,

        [Description("可用")]
        Disable = 0,
    }
}
