using System;

namespace ASample.NetCore.Product.Api
{
    public class ProductMemberPriceDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public Guid ProductUniqueId { get; set; }

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
