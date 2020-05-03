using System;

namespace ASample.NetCore.Subjects.Api
{
    public class HelpDto
    {
        public Guid? Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public bool ShowStatus { get; set; }
        public int ReadCount { get; set; }
        public string Content { get; set; }
    }
}
