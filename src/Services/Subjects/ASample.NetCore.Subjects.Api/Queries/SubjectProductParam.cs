using ASample.NetCore.Common;
using System;

namespace ASample.NetCore.Subjects.Api
{
    public class SubjectProductParam : PagedParam
    {
        public Guid SubjectId { get; set; }
    }
}
