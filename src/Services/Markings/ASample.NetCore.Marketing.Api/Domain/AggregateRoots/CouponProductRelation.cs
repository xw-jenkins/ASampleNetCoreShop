using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 优惠券和产品的关系表
    /// </summary>
    public class CouponProductRelation:AggregateRoot
    {
        public Guid CouponId { get; set; }
        public Guid ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string ProductSn { get; set; }
    }
}
