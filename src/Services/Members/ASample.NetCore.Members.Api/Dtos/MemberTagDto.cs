using System;

namespace ASample.NetCore.Members.Api
{
    public class MemberTagDto
    {
        public Guid? Id { get; set; }
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
