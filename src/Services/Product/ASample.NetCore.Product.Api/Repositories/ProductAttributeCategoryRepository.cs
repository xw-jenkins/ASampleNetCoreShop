using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductAttributeCategoryRepository : Repository<ProductApiContext, ProductAttributeCategory>,IProductAttributeCategoryRepository
    {
        public ProductAttributeCategoryRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
