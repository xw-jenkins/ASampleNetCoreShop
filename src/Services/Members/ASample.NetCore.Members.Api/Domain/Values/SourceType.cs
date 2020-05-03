using System.ComponentModel;

namespace ASample.NetCore.Members.Api.Domain
{
    public enum SourceType
    {
        [Description("购物")]
        Shopping,
        [Description("管理员修改")]
        AdminUpdate
    }
}
