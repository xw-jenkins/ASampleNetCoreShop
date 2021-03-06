using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class HomeNewProductRepository : Repository<MarketingApiContext, HomeNewProduct>, IHomeNewProductRepository
    {
        public HomeNewProductRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
