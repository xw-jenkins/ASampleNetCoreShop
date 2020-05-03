using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    /// <summary>
    /// 商品审核记录
    /// </summary>
    public class ProductVerifyRecord:AggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid? VerifyMan { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
    }
}
