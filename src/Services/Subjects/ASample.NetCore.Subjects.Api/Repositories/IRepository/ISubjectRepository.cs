using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task AddSubjectProductAsync(SubjectProductRelation entity);

        Task MutilAddSubjectProductAsync(List<SubjectProductRelation> entitys);

        Task<List<SubjectProductRelation>> GetSubjectProductsAsync(Guid subjectId);
    }
}
