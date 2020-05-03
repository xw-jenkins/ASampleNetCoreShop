using ASample.NetCore.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 角色菜单关联
    /// </summary>
    public class RoleClaim:IdentityRoleClaim<Guid>
    {
        public DateTime CreateTime { get; set; }
    }
}
