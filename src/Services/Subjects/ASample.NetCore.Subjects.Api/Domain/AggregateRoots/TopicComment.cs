using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Subjects.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 专题评论表
    /// </summary>
    public class TopicComment:AggregateRoot
    {
        public Guid TopicId { get; set; }

        public string MemberNickName { get; set; }
        public string MemberIcon { get; set; }
        public string Content { get; set; }
        public bool ShowStatus { get; set; }
    }
}
