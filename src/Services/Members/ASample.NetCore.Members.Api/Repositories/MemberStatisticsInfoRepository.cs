using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberStatisticsInfoRepository : Repository<MemberApiContext, MemberStatisticsInfo>, IMemberStatisticsInfoRepository
    {
        public MemberStatisticsInfoRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
