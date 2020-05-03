using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 优惠券使用、领取历史表
    /// </summary>
    public class CouponHistory:AggregateRoot
    {
        public Guid CouponId { get; set; }
        public Guid MemberId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        public string OrderSn { get; set; }
        public string CouponCode { get; set; }

        /// <summary>
        /// 领取人昵称
        /// </summary>
        public string MemberNickName { get; set; }

        /// <summary>
        /// 获取类型：0->后台赠送；1->主动获取
        /// </summary>
        public GetCouponType GetCouponType { get; set; }

        /// <summary>
        /// 使用状态：0->未使用；1->已使用；2->已过期
        /// </summary>
        public UseStatus UseStatus { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UseTime { get; set; }
    }
}
