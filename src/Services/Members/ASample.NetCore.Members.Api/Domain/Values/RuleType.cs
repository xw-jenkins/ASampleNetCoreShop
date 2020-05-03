using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum RuleType
    {
        [Description("积分规则")]
        PointsRule,
        [Description("成长值规则")]
        GrowthRule
    }
}
