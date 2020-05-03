using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum GetCouponType
    {
        [Description("后台赠送")]
        BackstageGift,
        [Description("主动获取")]
        ActiveAcquisition
    }
}
