using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class TopicCommentRepository : Repository<SubjectApiContext, TopicComment>, ITopicCommentRepository
    {
        public TopicCommentRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
