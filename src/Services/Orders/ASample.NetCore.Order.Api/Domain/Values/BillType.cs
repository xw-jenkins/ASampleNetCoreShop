using System.ComponentModel;

namespace ASample.NetCore.Order.Api.Domain
{
    public enum BillType
    {
        [Description("不开发票")]
        NotInvoiced = 0,
        [Description("电子发票")]
        ElectronicInvoice = 1,
        [Description("纸质发票")]
        PaperInvoice = 2,
    }
}
