using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum LoginType
    {
        [Description("PC")]
        PC,
        [Description("Android")]
        Android,
        [Description("Ios")]
        Ios,
        [Description("Wechat")]
        Wechat
    }
}
