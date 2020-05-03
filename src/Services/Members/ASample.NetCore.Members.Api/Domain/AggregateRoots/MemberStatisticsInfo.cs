using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 会员统计信息
    /// </summary>
    public class MemberStatisticsInfo:AggregateRoot
    {
        public Guid MemberId { get; set; }

        /// <summary>
        /// 累计消费金额
        /// </summary>
        public decimal ConsumeAmount { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderCount { get; set; }

        /// <summary>
        /// 优惠券数量
        /// </summary>
        public int CouponCount { get; set; }

        /// <summary>
        /// 评价数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int ReturnOrderCount { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount { get; set; }

        /// <summary>
        /// 关注数量
        /// </summary>
        public int AttendCount { get; set; }

        /// <summary>
        /// 粉丝数量
        /// </summary>
        public int FansCount { get; set; }

        /// <summary>
        /// 商品手机数量
        /// </summary>
        public int CollectProductCount { get; set; }

        /// <summary>
        /// 专题收集数量
        /// </summary>
        public int CollectSubjectCount { get; set; }

        /// <summary>
        /// 话题收集数量
        /// </summary>
        public int CollectTopicCount { get; set; }

        /// <summary>
        /// 评论收集数量
        /// </summary>
        public int CollectCommentCount { get; set; }

        /// <summary>
        /// 邀请好友数量
        /// </summary>
        public int InviteFriendCount { get; set; }

        /// <summary>
        /// 最近下单时间
        /// </summary>
        public DateTime RecentOrderTime { get; set; }
    }
}
