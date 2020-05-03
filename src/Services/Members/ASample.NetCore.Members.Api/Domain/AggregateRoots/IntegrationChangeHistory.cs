using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 积分变化历史记录表
    /// </summary>
    public class IntegrationChangeHistory:AggregateRoot
    {
        public Guid MemberId { get; set; }

        /// <summary>
        /// 改变类型：0->增加；1->减少
        /// </summary>
        public ChangeType ChangeType { get; set; }

        /// <summary>
        /// 积分改变数量
        /// </summary>
        public int ChangeCount { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperateMan { get; set; }

        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperateNote { get; set; }

        /// <summary>
        /// 积分来源：0->购物；1->管理员修改
        /// </summary>
        public SourceType SourceType { get; set; }
    }
}
