using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class GrowthChangeHistoryRepository : Repository<MemberApiContext, GrowthChangeHistory>, IGrowthChangeHistoryRepository
    {
        public GrowthChangeHistoryRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
