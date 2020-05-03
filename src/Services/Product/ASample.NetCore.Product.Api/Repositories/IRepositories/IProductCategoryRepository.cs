using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Domain.Entities;
using ASample.NetCore.RelationalDb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASample.NetCore.Product.Api.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task AddProductCateAttrAsync(ProductCategoryAttributeRelation entity);

        Task<List<ProductCategoryAttributeRelation>> QueryProductAttributeAsync(Guid productCateId);
    }
}
