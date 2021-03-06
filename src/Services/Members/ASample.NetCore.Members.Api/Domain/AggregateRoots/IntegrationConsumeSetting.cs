using ASample.NetCore.Domain;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 积分消费设置
    /// </summary>
    public class IntegrationConsumeSetting:AggregateRoot
    {
        /// <summary>
        /// 每一元需要抵扣的积分数量
        /// </summary>
        public int DeductionPerAmount { get; set; }

        /// <summary>
        /// 每笔订单最高抵用百分比
        /// </summary>
        public int MaxPercentPerOrder { get; set; }

        /// <summary>
        /// 每次使用积分最小单位100
        /// </summary>
        public int UseUnit { get; set; }

        /// <summary>
        /// 是否可以和优惠券同用；0->不可以；1->可以
        /// </summary>
        public CouponStatus CouponStatus { get; set; }
    }
}
