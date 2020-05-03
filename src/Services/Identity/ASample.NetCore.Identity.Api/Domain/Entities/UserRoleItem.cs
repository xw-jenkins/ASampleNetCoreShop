using Microsoft.AspNetCore.Identity;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    public class UserRoleItem:IdentityUserRole<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
