using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum UseStatus
    {
        [Description("未使用")]
        Unused,
        [Description("已使用")]
        Used,
        [Description("已过期")]
        Expired
    }
}
