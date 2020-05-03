using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductCategory:AggregateRoot
    {
        /// <summary>
        /// 父级
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        public string ProductUnit { get; set; }

        /// <summary>
        /// 导航状态
        /// </summary>
        public bool NavStatus { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool ShowStatus { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
}
