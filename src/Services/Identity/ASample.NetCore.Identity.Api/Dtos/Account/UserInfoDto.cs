using System.Collections.Generic;

namespace ASample.NetCore.Identity.Api.Dtos
{
    public class UserInfoDto
    {
        public string UserName { get; set; }
        public string Icon { get; set; }
        public List<string> Roles { get; set; }
    }
}
