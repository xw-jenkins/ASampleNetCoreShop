using System.ComponentModel;

namespace ASample.NetCore.Subjects.Api.Domain
{
    public enum HandleStatus
    {
        [Description("无效")]
        Invalid,
        [Description("有效")]
        Effective,
        [Description("恶意")]
        Malicious
    }
}
