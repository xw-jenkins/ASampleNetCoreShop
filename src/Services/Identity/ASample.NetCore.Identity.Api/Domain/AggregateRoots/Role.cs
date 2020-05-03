using ASample.NetCore.Domain;
using Microsoft.AspNetCore.Identity;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class Role:IdentityRole<Guid>,IAggregateRoot
    {
        /// <summary>
        /// 角色描述
        /// </summary>
        public Guid MsId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
