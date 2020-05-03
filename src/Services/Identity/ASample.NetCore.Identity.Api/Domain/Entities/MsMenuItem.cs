using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 系统菜单关联
    /// </summary>
    public class MsMenuItem:Entity<Guid>
    {

        /// <summary>
        /// 系统id
        /// </summary>
        public Guid MsId { get; set; }
        public Guid MenuId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
