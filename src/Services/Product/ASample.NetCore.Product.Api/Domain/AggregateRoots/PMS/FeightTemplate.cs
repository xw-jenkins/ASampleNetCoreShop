using ASample.NetCore.Domain;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 运费模版
    /// </summary>
    public class FeightTemplate:AggregateRoot
    {
        public string Name { get; set; }
        public int ChargeType { get; set; }
        public decimal FirstWeight { get; set; }
        public decimal FirstFee { get; set; }
        public decimal ContinueWeight { get; set; }
        public decimal ContinueFee { get; set; }
        public string Dest { get; set; }
    }
}
