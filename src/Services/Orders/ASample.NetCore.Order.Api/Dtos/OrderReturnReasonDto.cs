
using System;

namespace ASample.NetCore.Order.Api
{
    public class OrderReturnReasonDto
    {
        public Guid? Id { get; set; }
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
