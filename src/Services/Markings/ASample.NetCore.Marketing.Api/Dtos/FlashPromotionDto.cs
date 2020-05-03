using System;

namespace ASample.NetCore.Marketing.Api
{
    public class FlashPromotionDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 上下线状态
        /// </summary>
        public bool Status { get; set; }
    }
}
