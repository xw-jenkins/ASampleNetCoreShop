using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberLoginLogRepository : Repository<MemberApiContext, MemberLoginLog>, IMemberLoginLogRepository
    {
        public MemberLoginLogRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
