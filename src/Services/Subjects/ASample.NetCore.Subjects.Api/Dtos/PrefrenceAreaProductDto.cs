using System;
using System.Collections.Generic;

namespace ASample.NetCore.Subjects.Api
{
    public class PrefrenceAreaProductDto
    {
        public Guid PrefrenceAreaId { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
