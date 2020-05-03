using System.ComponentModel;

namespace ASample.NetCore.Identity.Api.Domain
{
    public enum GenderType
    {
        [Description("未知")]
        Unknow = 0,
        [Description("男")]
        Male = 1,
        [Description("女")]
        FeMale = 2,
    }
}
