using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class CouponProductCategoryRelationRepository : Repository<MarketingApiContext, CouponProductCategoryRelation>, ICouponProductCategoryRelationRepository
    {
        public CouponProductCategoryRelationRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
