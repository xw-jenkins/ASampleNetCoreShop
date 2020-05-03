using System;
using System.Collections.Generic;

namespace ASample.NetCore.Identity.Api
{
    public class UserRoleDto
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
