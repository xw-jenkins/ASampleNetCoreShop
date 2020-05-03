using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum TaskType
    {
        [Description("新手任务")]
        Novice,
        [Description("日常任务")]
        Daily
    }
}
