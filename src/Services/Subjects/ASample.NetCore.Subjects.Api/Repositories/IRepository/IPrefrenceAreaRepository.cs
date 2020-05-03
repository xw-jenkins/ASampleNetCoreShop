using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public interface IPrefrenceAreaRepository : IRepository<PrefrenceArea>
    {
        Task AddPrefrenceAreaProductAsync(PrefrenceAreaProductRelation entity);

        Task MutilAddPrefrenceAreaProductAsync(List<PrefrenceAreaProductRelation> entitys);

        Task<List<PrefrenceAreaProductRelation>> GetPrefrenceAreaProductsAsync(Guid subjectId);
    }
}
