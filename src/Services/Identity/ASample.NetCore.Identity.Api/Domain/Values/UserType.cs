using System.ComponentModel;

namespace ASample.NetCore.Identity.Api.Domain
{
    public enum UserType
    {
        [Description("管理用户")]
        MSUser = 0,

        [Description("会员用户")]
        Member = 1
    }
}
