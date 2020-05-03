using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 会员价格表
    /// </summary>
    public class ProductMemberPrice:AggregateRoot
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 会员等级编号
        /// </summary>
        public Guid MemberLevelId { get; set; }

        /// <summary>
        /// 会员等级名称
        /// </summary>
        public string MemberLevelName { get; set; }

        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
