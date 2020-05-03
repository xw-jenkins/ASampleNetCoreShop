using ASample.NetCore.Domain;

namespace ASample.NetCore.Product.Api.Domain.AggregateRoots
{
    public class ProductAttributeCategory:AggregateRoot
    {
        public string Name { get; set; }
        public int AttributeCount { get; set; }
        public int ParamCount { get; set; }
    }
}
