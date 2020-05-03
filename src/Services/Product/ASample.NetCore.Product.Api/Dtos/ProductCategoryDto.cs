using System;
using System.Collections.Generic;

namespace ASample.NetCore.Product.Api
{
    public class ProductCategoryDto
    {
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }

        public List<Guid> ProductAttributeIdList { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int ProductCount { get; set; }
        public string ProductUnit { get; set; }
        public bool NavStatus { get; set; }
        public int Sort { get; set; }
        public bool ShowStatus { get; set; }
        public string Icon { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public bool HasChildren { get; set; } = false;
    }
}
