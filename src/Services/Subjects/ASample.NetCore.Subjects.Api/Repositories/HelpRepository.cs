using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class HelpRepository : Repository<SubjectApiContext, Help>, IHelpRepository
    {
        public HelpRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
