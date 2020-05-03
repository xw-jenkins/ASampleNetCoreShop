using ASample.NetCore.Common;
using System;

namespace ASample.NetCore.Product.Api
{
    public class ProductAttributeParam : PagedParam
    {
        public Guid ProductAttributeCategoryId { get; set; }

        public int Type { get; set; }
    }
}
