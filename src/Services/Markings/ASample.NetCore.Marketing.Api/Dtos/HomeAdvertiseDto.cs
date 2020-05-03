using ASample.NetCore.Marketing.Api.Domain;
using System;

namespace ASample.NetCore.Marketing.Api
{
    public class HomeAdvertiseDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 轮播位置：0->PC首页轮播；1->app首页轮播
        /// </summary>
        public CarouselType Type { get; set; }
        public string Pic { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }

        /// <summary>
        /// 上下线状态：0->下线；1->上线
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 点击数
        /// </summary>
        public string ClickCount { get; set; }

        /// <summary>
        /// 下单数
        /// </summary>
        public string OrderCount { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
