using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class BrandRepository : Repository<ProductApiContext, Brand>,IBrandRepository
    {
        public BrandRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
