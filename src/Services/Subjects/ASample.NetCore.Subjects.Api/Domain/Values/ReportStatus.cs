using System.ComponentModel;

namespace ASample.NetCore.Subjects.Api.Domain
{
    public enum ReportStatus
    {
        [Description("未处理")]
        UnProcessed,
        [Description("已处理")]
        Processed
    }
}
