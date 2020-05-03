using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class SubjectCommentRepository : Repository<SubjectApiContext, SubjectComment>, ISubjectCommentRepository
    {
        public SubjectCommentRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
