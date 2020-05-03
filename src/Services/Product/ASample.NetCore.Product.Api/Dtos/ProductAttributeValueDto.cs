using System;

namespace ASample.NetCore.Product.Api
{
    public class ProductAttributeValueDto
    {
        public Guid? Id { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string Value { get; set; }
    }
}
