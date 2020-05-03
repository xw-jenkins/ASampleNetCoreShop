using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum CouponStatus
    {
        [Description("积分规则")]
        PointsRule,
        [Description("成长值规则")]
        GrowthValueRule
    }
}
