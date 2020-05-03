using System.ComponentModel;

namespace ASample.NetCore.Marketing.Api.Domain
{
    public enum CouponType
    {
        [Description("全场赠券")]
        FullCoupon,
        [Description("会员赠券")]
        MemberCoupon,
        [Description("购物赠券")]
        ShoppingCoupon,
        [Description("注册赠券")]
        RegistrationCoupon
    }
}
