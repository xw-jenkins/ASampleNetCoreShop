using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 新鲜好物表
    /// </summary>
    public class HomeNewProduct:AggregateRoot
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
