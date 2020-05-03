using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{

    /// <summary>
    /// 限时购通知记录
    /// </summary>
    public class FlashPromotionLog:AggregateRoot
    {
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
        public string MemberPhone { get; set; }
        public string ProductName { get; set; }

        /// <summary>
        /// 会员订阅时间
        /// </summary>
        public DateTime SubscribeTime { get; set; }
        public DateTime? SendTime { get; set; }
    }
}
