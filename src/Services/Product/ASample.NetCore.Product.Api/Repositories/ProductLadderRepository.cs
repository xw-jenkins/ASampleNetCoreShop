using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductLadderRepository : Repository<ProductApiContext, ProductLadder>, IProductLadderRepository
    {
        public ProductLadderRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
