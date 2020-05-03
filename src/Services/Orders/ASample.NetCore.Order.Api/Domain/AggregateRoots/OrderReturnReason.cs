using ASample.NetCore.Domain;

namespace ASample.NetCore.Order.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 退货原因表
    /// </summary>
    public class OrderReturnReason:AggregateRoot
    {
        /// <summary>
        /// 退货类型
        /// </summary>
        public string Name { get; set; }
        public int Sort { get; set; }

        /// <summary>
        /// 状态：0->不启用；1->启用
        /// </summary>
        public bool Status { get; set; }
    }
}
