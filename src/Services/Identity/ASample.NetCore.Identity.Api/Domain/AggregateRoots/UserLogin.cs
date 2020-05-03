using ASample.NetCore.Domain;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    public class UserLogin : IdentityUserLogin<Guid>,IAggregateRoot
    {
        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get ; set ; }
        public string LoginIp { get ; set ; }
    }
}
