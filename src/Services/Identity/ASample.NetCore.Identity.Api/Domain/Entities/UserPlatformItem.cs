using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    public class UserPlatformItem:AggregateRoot
    {
        public Guid UserId { get; set; }
        public Guid PlatformId { get; set; }
        public string PlatformToken { get; set; }
        public PlatformType Type { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
    }
}
