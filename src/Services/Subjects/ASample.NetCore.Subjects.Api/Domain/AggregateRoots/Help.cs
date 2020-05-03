using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Subjects.Api.Domain.AggregateRoots
{

    /// <summary>
    /// 帮助表
    /// </summary>
    public class Help:AggregateRoot
    {
        public Guid CategoryId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public bool ShowStatus { get; set; }
        public int ReadCount { get; set; }
        public string Content { get; set; }
    }
}
