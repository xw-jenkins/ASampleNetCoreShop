using System;
using System.Collections.Generic;

namespace ASample.NetCore.Product.Api
{
    /// <summary>
    /// 获取产品类型下的属性
    /// </summary>
    public class ProductAttrCateWithAttrDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<ProductAttributeDto> ProductAttributes { get; set; }
    }
}
