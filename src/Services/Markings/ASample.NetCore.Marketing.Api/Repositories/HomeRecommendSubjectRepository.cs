using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class CouponHistoryRepository : Repository<MarketingApiContext, CouponHistory>, ICouponHistoryRepository
    {
        public CouponHistoryRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
