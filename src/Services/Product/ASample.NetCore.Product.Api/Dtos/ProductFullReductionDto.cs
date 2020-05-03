using System;

namespace ASample.NetCore.Product.Api
{
    public class ProductFullReductionDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal FullPrice { get; set; }
        public decimal ReducePrice { get; set; }
    }
}
