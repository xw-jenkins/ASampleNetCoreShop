using System;

namespace ASample.NetCore.Product.Api
{
    public class ProductLadderDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }

        public int Count { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
    }
}
