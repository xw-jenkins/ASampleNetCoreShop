using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Marketing.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 首页推荐专题表
    /// </summary>
    public class HomeRecommendSubject:AggregateRoot
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
