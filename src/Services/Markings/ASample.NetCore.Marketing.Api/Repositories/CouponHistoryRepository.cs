using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Marketing.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Marketing.Api.Repositories
{
    public class HomeRecommendSubjectRepository : Repository<MarketingApiContext, HomeRecommendSubject>, IHomeRecommendSubjectRepository
    {
        public HomeRecommendSubjectRepository(IUnitOfWork<MarketingApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
