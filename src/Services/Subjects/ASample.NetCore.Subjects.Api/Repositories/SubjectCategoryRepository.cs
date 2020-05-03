using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class SubjectCategoryRepository : Repository<SubjectApiContext, SubjectCategory>, ISubjectCategoryRepository
    {
        public SubjectCategoryRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
