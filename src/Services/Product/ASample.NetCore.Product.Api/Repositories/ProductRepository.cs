using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductRepository : Repository<ProductApiContext, Products>,IProductRepository
    {
        public ProductRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
