using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum CarouselType
    {
        [Description("PC首页轮播")]
        PC,
        [Description("app首页轮播")]
        APP
    }
}
