using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.Entities
{
    public class ProductCategoryAttributeRelation:AggregateRoot,IAggregateRoot
    {
        /// <summary>
        /// 商品类别编号
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// 商品属性编号
        /// </summary>
        public Guid ProductAttributeId { get; set; }
    }
}
