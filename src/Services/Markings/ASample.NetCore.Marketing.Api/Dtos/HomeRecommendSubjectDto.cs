using System;

namespace ASample.NetCore.Marketing.Api
{
    public class HomeRecommendSubjectDto
    {
        public Guid? Id { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool RecommendStatus { get; set; }
        public int Sort { get; set; }
    }
}
