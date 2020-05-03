using System.ComponentModel;

namespace ASample.NetCore.Identity.Api.Domain
{
    public enum MemberRoleType
    {
        [Description("普通用户")]
        Normal = 0,

        [Description("VIP用户")]
        Vip = 1
    }
}
