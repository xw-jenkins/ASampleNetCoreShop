using Microsoft.AspNetCore.Identity;
using System;
namespace ASample.NetCore.Identity.Api.Domain
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
