using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductSkuStockRepository : Repository<ProductApiContext, ProductSkuStock>, IProductSkuStockRepository
    {
        public ProductSkuStockRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
