using System;

namespace ASample.NetCore.Identity.Api
{
    public class RoleDto
    {
        public Guid? Id { get; set; }
        public Guid MsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
