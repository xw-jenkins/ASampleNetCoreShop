using System;
using System.Collections.Generic;

namespace ASample.NetCore.Identity.Api
{
    public class RoleMenuDto
    {
        public Guid RoleId { get; set; }
        public List<Guid> MenuIds { get; set; }
    }
}
