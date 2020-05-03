using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class Comment:AggregateRoot
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string MemberNickName { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 星级
        /// </summary>
        public string Star { get; set; }

        /// <summary>
        /// 会员IP
        /// </summary>
        public string MemberIp { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool ShowStatus { get; set; }

        /// <summary>
        /// 产品属性
        /// </summary>
        public string ProductAttribute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CollectCount { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadCount { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Pics { get; set; }

        /// <summary>
        /// 会员头像
        /// </summary>
        public string MemberIcon { get; set; }

        /// <summary>
        /// 回复数量
        /// </summary>
        public int ReplayCount { get; set; }
    }
}
