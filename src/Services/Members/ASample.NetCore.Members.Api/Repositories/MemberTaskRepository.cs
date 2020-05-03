using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberTaskRepository : Repository<MemberApiContext, MemberTask>, IMemberTaskRepository
    {
        public MemberTaskRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
