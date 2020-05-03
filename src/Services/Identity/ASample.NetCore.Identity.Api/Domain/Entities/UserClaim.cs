using ASample.NetCore.Domain;
using Microsoft.AspNetCore.Identity;
using System;


namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 角色员工关联
    /// </summary>
    public class UserClaim:IdentityUserClaim<Guid>
    {
        public DateTime CreateTime { get; set; }
    }
}
