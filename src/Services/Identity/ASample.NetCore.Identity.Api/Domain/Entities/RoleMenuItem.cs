using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 角色菜单关联
    /// </summary>
    public class RoleMenuItem:Entity<Guid>
    {

        /// <summary>
        /// 角色id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public Guid MenuId { get; set; }
    }
}
