using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class FlashPromotionLogRepository : Repository<MarketingApiContext, FlashPromotionLog>, IFlashPromotionLogRepository
    {
        public FlashPromotionLogRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
