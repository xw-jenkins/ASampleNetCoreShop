using System;

namespace ASample.NetCore.Members.Api
{
    public class MemberLevelDto
    {
        public Guid? Id { get; set; }
        public Guid MsId { get; set; }

        public string Name { get; set; }
        public int GrowthPoint { get; set; }
        public bool DefaultStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FreeFreightPoint { get; set; }

        /// <summary>
        /// 评论积分奖励
        /// </summary>
        public int CommentGrowthPoint { get; set; }

        /// <summary>
        /// 免运费特权
        /// </summary>
        public bool PriviledgeFreeFreight { get; set; }

        /// <summary>
        /// 登录特权
        /// </summary>
        public bool PriviledgeSignIn { get; set; }

        /// <summary>
        /// 评论特权
        /// </summary>
        public bool PriviledgeComment { get; set; }

        /// <summary>
        /// 优惠促销
        /// </summary>
        public bool PriviledgePromotion { get; set; }

        /// <summary>
        /// 会员价特权
        /// </summary>
        public bool PriviledgeMemberPrice { get; set; }

        /// <summary>
        /// 生日特权
        /// </summary>
        public bool PriviledgeBirthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }
    }
}
