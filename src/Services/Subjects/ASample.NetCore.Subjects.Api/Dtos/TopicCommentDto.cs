using System;

namespace ASample.NetCore.Subjects.Api
{
    public class TopicCommentDto
    {
        public Guid? Id { get; set; }
        public Guid TopicId { get; set; }

        public string MemberNickName { get; set; }
        public string MemberIcon { get; set; }
        public string Content { get; set; }
        public bool ShowStatus { get; set; }
    }
}
