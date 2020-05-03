using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductAttribute:AggregateRoot
    {
        /// <summary>
        /// 商品属性类别编号
        /// </summary>
        public Guid ProductAttributeCategoryId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 选择类别
        /// </summary>
        public int SelectType { get; set; }

        /// <summary>
        /// 输入类别
        /// </summary>
        public int InputType { get; set; }

        /// <summary>
        /// 输入列表
        /// </summary>
        public string InputList { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FilterType { get; set; }
        public int SearchType { get; set; }
        public int RelatedStatus { get; set; }
        public int AddHandStatus { get; set; }
        public int Type { get; set; }
    }
}
