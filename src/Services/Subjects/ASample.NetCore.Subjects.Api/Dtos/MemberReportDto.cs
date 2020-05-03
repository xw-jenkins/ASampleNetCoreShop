using ASample.NetCore.Subjects.Api.Domain;
using System;

namespace ASample.NetCore.Subjects.Api
{
    public class MemberReportDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 举报类型：0->商品评价；1->话题内容；2->用户评论
        /// </summary>
        public ReportType ReportType { get; set; }

        /// <summary>
        /// 举报人
        /// </summary>
        public string ReportMemberName { get; set; }
        public string ReportObject { get; set; }

        /// <summary>
        /// 举报状态：0->未处理；1->已处理
        /// </summary>
        public ReportStatus ReportStatus { get; set; }

        /// <summary>
        /// 处理结果：0->无效；1->有效；2->恶意
        /// </summary>
        public HandleStatus HandleStatus { get; set; }
        public string Note { get; set; }
    }
}
