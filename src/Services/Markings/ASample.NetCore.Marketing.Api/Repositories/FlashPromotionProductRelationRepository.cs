using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class FlashPromotionProductRelationRepository : Repository<MarketingApiContext, FlashPromotionProductRelation>, IFlashPromotionProductRelationRepository
    {
        public FlashPromotionProductRelationRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
