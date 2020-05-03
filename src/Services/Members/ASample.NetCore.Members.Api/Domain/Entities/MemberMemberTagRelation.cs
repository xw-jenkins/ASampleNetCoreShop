using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Members.Api.Domain.Entities
{
    /// <summary>
    /// 用户和标签关系表
    /// </summary>
    public class MemberMemberTagRelation:AggregateRoot
    {
        public Guid MemberId { get; set; }
        public Guid TagId { get; set; }
    }
}
