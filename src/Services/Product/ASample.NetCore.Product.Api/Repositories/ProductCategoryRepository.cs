using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.Product.Api.Domain.Entities;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductCategoryRepository : Repository<ProductApiContext, ProductCategory>,IProductCategoryRepository
    {
        private readonly IUnitOfWork<ProductApiContext> _unitOfWork;
        public ProductCategoryRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productCateAttrSet = unitOfWork.GetDbContext().Set<ProductCategoryAttributeRelation>();
        }
        public DbSet<ProductCategoryAttributeRelation> _productCateAttrSet;

        public async Task AddProductCateAttrAsync(ProductCategoryAttributeRelation entity)
        {
            _productCateAttrSet.Add(entity);
        }

        public async Task<List<ProductCategoryAttributeRelation>> QueryProductAttributeAsync(Guid productCateId)
        {
            var result = await _productCateAttrSet.Where(c => c.ProductCategoryId == productCateId).ToListAsync();
            return result;
        }
    }
}
