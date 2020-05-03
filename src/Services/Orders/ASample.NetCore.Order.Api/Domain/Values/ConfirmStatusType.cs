using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum ConfirmStatusType
    {
        [Description("未确认")]
        UnConfirmed = 0,
        [Description("已确认")]
        Confirmed = 1,
    }
}
