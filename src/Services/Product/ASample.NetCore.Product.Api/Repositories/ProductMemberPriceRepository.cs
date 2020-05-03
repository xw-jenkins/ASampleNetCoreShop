using ASample.NetCore.Product.Api.Domain.AggregateRoots;
using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Product.Api.Repositories
{
    public class ProductMemberPriceRepository : Repository<ProductApiContext, ProductMemberPrice>, IProductMemberPriceRepository
    {
        public ProductMemberPriceRepository(IUnitOfWork<ProductApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
