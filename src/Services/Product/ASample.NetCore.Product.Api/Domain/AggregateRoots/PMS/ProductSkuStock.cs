using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 商品库存
    /// </summary>
    public class ProductSkuStock:AggregateRoot
    {
        /// <summary>
        /// 产品
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// sku编码
        /// </summary>
        public string SkuCode { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal  Price { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int  Stock { get; set; }

        /// <summary>
        /// 预警库存
        /// </summary>
        public int  LowStock { get; set; }

        /// <summary>
        /// 销售属性1
        /// </summary>
        public string  Sp1 { get; set; }

        /// <summary>
        /// 销售属性2
        /// </summary>
        public string  Sp2 { get; set; }

        /// <summary>
        /// 销售属性3
        /// </summary>
        public string  Sp3 { get; set; }

        /// <summary>
        /// 展示图片
        /// </summary>
        public string  Pic { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int  Sale { get; set; }

        /// <summary>
        /// 单品促销价格
        /// </summary>
        public decimal  PromotionPric { get; set; }

        /// <summary>
        /// 锁定库存
        /// </summary>
        public int  LockStock { get; set; }
    }
}
