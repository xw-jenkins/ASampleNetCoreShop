using ASample.NetCore.Identity.Api.Domain;
using System;

namespace ASample.NetCore.Identity.Api.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid? MsId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 上一次登录Ip
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes { get; set; }

        public UserType? UserType { get; set; }

        public PlatformType? UserSource { get; set; }
    }
}
