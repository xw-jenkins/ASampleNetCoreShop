using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class CommentReplay : AggregateRoot
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public Guid CommentId { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string MemberNickName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 会员头像
        /// </summary>
        public string MemberIcon { get; set; }
        public int ReplayType { get; set; }
    }
}
