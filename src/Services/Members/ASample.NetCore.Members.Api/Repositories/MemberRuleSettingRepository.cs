using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class MemberRuleSettingRepository : Repository<MemberApiContext, MemberRuleSetting>, IMemberRuleSettingRepository
    {
        public MemberRuleSettingRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
