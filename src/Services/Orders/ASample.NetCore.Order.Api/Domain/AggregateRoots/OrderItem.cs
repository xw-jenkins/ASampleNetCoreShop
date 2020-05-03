using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Order.Api.Domain.AggregateRoots
{
    public class OrderItem:AggregateRoot
    {
        public Guid OrderId { get; set; }
        public string OrderSn { get; set; }
        public Guid ProductId { get; set; }
        public string ProductPic { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductSn { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// 商品sku编号
        /// </summary>
        public Guid ProductSkuId { get; set; }

        /// <summary>
        /// 商品sku条码
        /// </summary>
        public string ProductSkuCode { get; set; }

        /// <summary>
        /// 商品分类id
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// 商品的销售属性
        /// </summary>
        public string Sp1 { get; set; }
        public string Sp2 { get; set; }
        public string Sp3 { get; set; }

        /// <summary>
        /// 商品促销名称
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// 商品促销分解金额
        /// </summary>
        public decimal PromotionAmount { get; set; }

        /// <summary>
        /// 优惠券优惠分解金额
        /// </summary>
        public decimal CouponAmount { get; set; }

        /// <summary>
        /// 积分优惠分解金额
        /// </summary>
        public decimal IntegrationAmount { get; set; }

        /// <summary>
        /// 该商品经过优惠后的分解金额
        /// </summary>
        public decimal RealAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal GiftIntegration { get; set; }

        public decimal GiftGrowth { get; set; }

        /// <summary>
        /// 商品销售属性:[{"key":"颜色","value":"颜色"},{"key":"容量","value":"4G"}]
        /// </summary>
        public string ProductAttr { get; set; }
    }
}
