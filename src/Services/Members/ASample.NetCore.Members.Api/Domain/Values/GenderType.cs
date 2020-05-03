using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum GenderType
    {
        [Description("未知")]
        Unknown,
        [Description("男")]
        Male,
        [Description("女")]
        Femalem,

    }
}
