using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class HomeBrandRepository : Repository<MarketingApiContext, HomeBrand>, IHomeBrandRepository
    {
        public HomeBrandRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
