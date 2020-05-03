using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class HomeAdvertiseRepository : Repository<MarketingApiContext, HomeAdvertise>, IHomeAdvertiseRepository
    {
        public HomeAdvertiseRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
