using ASample.NetCore.Domain;

namespace ASample.NetCore.Subjects.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 话题分类表
    /// </summary>
    public class TopicCategory:AggregateRoot
    {
        public string Name { get; set; }

        /// <summary>
        /// 分类图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 专题数量
        /// </summary>
        public int SubjectCount { get; set; }
        public bool ShowStatus { get; set; }
        public int Sort { get; set; }
    }
}
