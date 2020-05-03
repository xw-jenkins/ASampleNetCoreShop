using ASample.NetCore.Common;
using ASample.NetCore.Members.Api.Domain;

namespace ASample.NetCore.Members.Api
{
    public class MemberRuleSettingParam : PagedParam
    {
        public RuleType Type { get; set; }
    }
}
