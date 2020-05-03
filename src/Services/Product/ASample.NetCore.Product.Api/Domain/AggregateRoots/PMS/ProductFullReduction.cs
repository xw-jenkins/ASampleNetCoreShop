using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductFullReduction:AggregateRoot
    {
        public Guid ProductId { get; set; }
        public decimal  FullPrice { get; set; }
        public decimal  ReducePrice { get; set; }
    }
}
