using System;

namespace ASample.NetCore.Subjects.Api
{
    public class TopicCategoryDto
    {
        public Guid? Id { get; set; }
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
