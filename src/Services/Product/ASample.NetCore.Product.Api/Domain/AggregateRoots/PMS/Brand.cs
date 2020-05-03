using ASample.NetCore.Domain;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class Brand:AggregateRoot
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 品牌首字母
        /// </summary>
        public string FirstLetter { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 品牌制造商
        /// </summary>
        public bool FactoryStatus { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool ShowStatus { get; set; }

        /// <summary>
        /// 品牌拥有商品数量
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// 品牌下商品评论数量
        /// </summary>
        public int ProductCommentCount { get; set; }

        /// <summary>
        /// 品牌logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 品牌大图
        /// </summary>
        public string BigPic { get; set; }

        /// <summary>
        /// 品牌故事
        /// </summary>
        public string BrandStory { get; set; }
    }
}
