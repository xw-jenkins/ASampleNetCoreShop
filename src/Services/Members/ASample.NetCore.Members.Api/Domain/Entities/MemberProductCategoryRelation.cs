using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Members.Api.Domain.Entities
{
    /// <summary>
    /// 会员与产品分类关系表（用户喜欢的分类）
    /// </summary>
    public class MemberProductCategoryRelation:AggregateRoot
    {
        public Guid MemberId { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
