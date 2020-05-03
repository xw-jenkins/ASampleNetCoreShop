using System.ComponentModel;

namespace ASample.NetCore.Subjects.Api.Domain
{
    public enum ReportType
    {
        [Description("商品评价")]
        ProductReview,
        [Description("话题内容")]
        TopicContent,
        [Description("用户评论")]
        UserComment
    }
}
