using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Order.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 购物车表
    /// </summary>
    public class CartItem:AggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid ProductSkuId { get; set; }
        public Guid MemberId { get; set; }


        /// <summary>
        /// 商品分类
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 添加到购物车的价格
        /// </summary>
        public decimal Price { get; set; }
        public string Sp1 { get; set; }
        public string Sp2 { get; set; }
        public string Sp3 { get; set; }

        /// <summary>
        /// 商品主图
        /// </summary>
        public string ProductPic { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品副标题（卖点）
        /// </summary>
        public string ProductSubTitle { get; set; }

        /// <summary>
        /// 商品sku条码
        /// </summary>
        public string ProductSkuCode { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string MemberNickName { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool DeleteStatus { get; set; }
        
        /// <summary>
        /// 商品品牌
        /// </summary>
        public string ProductBrand { get; set; }

        /// <summary>
        /// 商品序列号
        /// </summary>
        public string ProductSn { get; set; }

        /// <summary>
        /// 商品销售属性:[{"key":"颜色","value":"颜色"},{"key":"容量","value":"4G"}]
        /// </summary>
        public string ProductAttr { get; set; }
    }
}
