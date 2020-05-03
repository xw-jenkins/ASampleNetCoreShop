using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 会员等级表
    /// </summary>
    public class MemberLevel:AggregateRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public Guid MsId { get; set; }
        public int GrowthPoint { get; set; }

        /// <summary>
        /// 是否为默认等级：0->不是；1->是
        /// </summary>
        public bool DefaultStatus { get; set; }

        /// <summary>
        /// 免运费标准
        /// </summary>
        public decimal FreeFreightPoint { get; set; }

        /// <summary>
        ///每次评价获取的成长值
        /// </summary>
        public int CommentGrowthPoint { get; set; }

        /// <summary>
        /// 是否有免邮特权
        /// </summary>
        public bool PriviledgeFreeFreight { get; set; }

        /// <summary>
        /// 是否有签到特权
        /// </summary>
        public bool PriviledgeSignIn { get; set; }

        /// <summary>
        /// 是否有评论获奖励特权
        /// </summary>
        public bool PriviledgeComment { get; set; }

        /// <summary>
        /// 是否有专享活动特权
        /// </summary>
        public bool PriviledgePromotion { get; set; }

        /// <summary>
        /// 是否有会员价格特权
        /// </summary>
        public bool PriviledgeMemberPrice { get; set; }

        /// <summary>
        /// 是否有生日特权
        /// </summary>
        public bool PriviledgeBirthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string  Note { get; set; }
    }
}
