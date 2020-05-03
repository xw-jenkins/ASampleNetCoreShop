using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 首页推荐品牌表
    /// </summary>
    public class HomeBrand:AggregateRoot
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
