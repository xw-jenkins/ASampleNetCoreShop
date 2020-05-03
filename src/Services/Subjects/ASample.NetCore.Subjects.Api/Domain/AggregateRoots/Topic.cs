using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Subjects.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 话题表
    /// </summary>
    public class Topic:AggregateRoot
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 参与人数
        /// </summary>
        public int AttendCount { get; set; }

        /// <summary>
        /// 关注人数
        /// </summary>
        public int AttentionCount { get; set; }
        public int ReadCount { get; set; }

        /// <summary>
        /// 奖品名称
        /// </summary>
        public string AwardName { get; set; }

        /// <summary>
        /// 参与方式
        /// </summary>
        public string AttendType { get; set; }

        /// <summary>
        /// 话题内容
        /// </summary>
        public string Content { get; set; }
    }
}
