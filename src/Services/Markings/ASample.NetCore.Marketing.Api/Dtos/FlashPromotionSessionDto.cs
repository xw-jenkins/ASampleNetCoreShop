using System;

namespace ASample.NetCore.Marketing.Api
{
    public class FlashPromotionSessionDto
    {
        public Guid? Id { get; set; }
        public Guid FlashPromotionId { get; set; }
        /// <summary>
        /// 场次名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 每日开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 每日结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 启用状态：0->不启用；1->启用
        /// </summary>
        public bool Status { get; set; }
    }
}
