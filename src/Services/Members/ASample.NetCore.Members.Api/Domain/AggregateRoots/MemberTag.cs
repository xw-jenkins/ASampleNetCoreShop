using ASample.NetCore.Domain;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 用户标签表
    /// </summary>
    public class MemberTag:AggregateRoot
    {
        public string Name { get; set; }

        /// <summary>
        /// 自动打标签完成订单数量
        /// </summary>
        public int FinishOrderCount { get; set; }

        /// <summary>
        /// 自动打标签完成订单金额
        /// </summary>
        public decimal FinishOrderAmount { get; set; }
    }
}
