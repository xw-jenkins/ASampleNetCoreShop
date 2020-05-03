using ASample.NetCore.Domain;
using System;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductAttributeValue:AggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string Value { get; set; }
    }
}
