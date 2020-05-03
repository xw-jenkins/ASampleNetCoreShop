using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class HomeRecommendProductRepository : Repository<MarketingApiContext, HomeRecommendProduct>, IHomeRecommendProductRepository
    {
        public HomeRecommendProductRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
