using ASample.NetCore.Domain;
using System;
namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 优惠券和产品分类关系表
    /// </summary>
    public class CouponProductCategoryRelation:AggregateRoot
    {
        public Guid CouponId { get; set; }
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// 父分类名称
        /// </summary>
        public string ParentCategoryName { get; set; }
    }
}
