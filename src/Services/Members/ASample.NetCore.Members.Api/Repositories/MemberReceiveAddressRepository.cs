using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberReceiveAddressRepository : Repository<MemberApiContext, MemberReceiveAddress>, IMemberReceiveAddressRepository
    {
        public MemberReceiveAddressRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
