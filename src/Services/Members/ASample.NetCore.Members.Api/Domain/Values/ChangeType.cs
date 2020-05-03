using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum ChangeType
    {
        [Description("增加")]
        Add,
        [Description("减少")]
        Decrease
    }
}
