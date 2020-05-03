using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 商品操作记录      
    /// </summary>
    public class ProductOperateLog:AggregateRoot
    {
        public Guid ProductId { get; set; }

        public decimal PriceOld { get; set; }
        public decimal PriceNew { get; set; }
        public decimal SalePriceOld { get; set; }
        public decimal SalePriceNew { get; set; }
        public decimal GiftPointOld { get; set; }
        public decimal GiftPointNew { get; set; }
        public decimal UseGiftPointLimitOld { get; set; }
        public decimal UseGiftPointLimitNew { get; set; }
        public Guid? OperateUser { get; set; }
    }
}
