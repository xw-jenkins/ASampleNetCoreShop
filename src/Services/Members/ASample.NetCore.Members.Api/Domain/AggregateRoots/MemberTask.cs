using ASample.NetCore.Domain;

namespace ASample.NetCore.Members.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 会员任务表
    /// </summary>
    public class MemberTask:AggregateRoot
    {
        public string Name { get; set; }

        /// <summary>
        /// 赠送成长值
        /// </summary>
        public int Growth { get; set; }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public int Intergration { get; set; }

        /// <summary>
        /// 任务类型：0->新手任务；1->日常任务
        /// </summary>
        public TaskType TaskType { get; set; }
    }
}
