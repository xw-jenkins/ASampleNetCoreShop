using ASample.NetCore.EntityFramwork;
using ASample.NetCore.Members.Api.Domain.AggregateRoots;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Members.Api.Repositories
{
    public class IntegrationConsumeSettingRepository : Repository<MemberApiContext, IntegrationConsumeSetting>, IIntegrationConsumeSettingRepository
    {
        public IntegrationConsumeSettingRepository(IUnitOfWork<MemberApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
