using ASample.NetCore.Members.Api.Domain;
using System;

namespace ASample.NetCore.Members.Api
{
    public class MemberLoginLogDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public Guid MemberId { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 登录城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 登录类型：0->PC；1->android;2->ios;3->小程序
        /// </summary>
        public LoginType LoginType { get; set; }

        /// <summary>
        /// 省会
        /// </summary>
        public string Province { get; set; }
    }
}
