using System;
using System.Collections.Generic;

namespace ASample.NetCore.Subjects.Api
{
    public class SubjectProductDto
    {
        public Guid SubjectId { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
