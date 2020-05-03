using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class TopicRepository : Repository<SubjectApiContext, Topic>, ITopicRepository
    {
        public TopicRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {

        }
    }
}
