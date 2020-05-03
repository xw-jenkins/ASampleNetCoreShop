using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum PlatformType
    {
        [Description("全部")]
        ALL,
        [Description("移动")]
        APP,
        [Description("PC")]
        PC
    }
}
