using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductAttributeRepository : Repository<ProductApiContext, ProductAttribute>,IProductAttributeRepository
    {
        public ProductAttributeRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
