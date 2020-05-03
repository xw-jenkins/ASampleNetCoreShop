
using System.ComponentModel;

namespace ASample.NetCore.Identity.Api.Domain
{
    public enum PlatformType
    {
        [Description("未知")]
        UnKnow = 0,

        [Description("Facebook")]
        Facebook = 1,

        [Description("Google")]
        Google = 2,

        [Description("微信")]
        Wechat = 3,

        [Description("QQ")]
        QQ = 4,

        [Description("新浪微博")]
        Weibo = 5,

        [Description("Twitter")]
        Twitter = 6,
    }
}
