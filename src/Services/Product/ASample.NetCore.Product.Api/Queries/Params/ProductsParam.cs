using ASample.NetCore.Common;

namespace ASample.NetCore.Product.Api
{
    public class ProductsParam: PagedParam
    {
        /// <summary>
        /// 是否新品
        /// </summary>
        public bool? NewStatus { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? RecommendStatus { get; set; }
    }
}
