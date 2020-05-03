using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberRepository : Repository<MemberApiContext, Member>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
