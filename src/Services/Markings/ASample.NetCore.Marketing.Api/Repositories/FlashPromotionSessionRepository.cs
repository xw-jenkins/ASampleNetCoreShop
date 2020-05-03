using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class FlashPromotionSessionRepository : Repository<MarketingApiContext, FlashPromotionSession>, IFlashPromotionSessionRepository
    {
        public FlashPromotionSessionRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
