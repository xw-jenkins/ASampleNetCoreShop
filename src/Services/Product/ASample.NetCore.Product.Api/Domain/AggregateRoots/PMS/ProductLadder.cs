using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductLadder:AggregateRoot
    {
        public Guid ProductId { get; set; }

        public int Count { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
    }
}
