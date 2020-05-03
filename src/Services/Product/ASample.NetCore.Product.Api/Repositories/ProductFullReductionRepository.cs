using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductFullReductionRepository : Repository<ProductApiContext, ProductFullReduction>, IProductFullReductionRepository
    {
        public ProductFullReductionRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
