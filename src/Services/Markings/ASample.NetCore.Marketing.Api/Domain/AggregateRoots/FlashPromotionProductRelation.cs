using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{

    /// <summary>
    /// 商品限时购与商品关系表 
    /// </summary>
    public class FlashPromotionProductRelation:AggregateRoot
    {
        public Guid FlashPromotionId { get; set; }
        public Guid FlashPromotionSessionId { get; set; }
        public Guid ProductId { get; set; }

        /// <summary>
        /// 限时购价格
        /// </summary>
        public decimal FlashPromotionPrice { get; set; }

        /// <summary>
        /// 限时购数量
        /// </summary>
        public int FlashPromotionCount { get; set; }

        /// <summary>
        /// 每人限购数量
        /// </summary>
        public int FlashPromotionLimit { get; set; }
        public int Sort { get; set; }
    }
}
