using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class IntegrationChangeHistoryRepository : Repository<MemberApiContext, IntegrationChangeHistory>, IIntegrationChangeHistoryRepository
    {
        public IntegrationChangeHistoryRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
