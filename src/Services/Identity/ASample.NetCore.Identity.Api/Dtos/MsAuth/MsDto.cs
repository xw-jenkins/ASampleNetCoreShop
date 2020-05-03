using System;

namespace ASample.NetCore.Identity.Api
{
    public class MsDto
    {
        public Guid Id { get; set; }
        public string MsName { get; set; }
        public string MsDescription { get; set; }
        public string MsDomain { get; set; }
    }
}
