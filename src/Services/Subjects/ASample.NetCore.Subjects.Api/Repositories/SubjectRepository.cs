using ASample.NetCore.EntityFramwork;
using ASample.NetCore.RelationalDb;
using ASample.NetCore.Subjects.Api.Domain.AggregateRoots;
using ASample.NetCore.Subjects.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.Subjects.Api.Repositories
{
    public class SubjectRepository : Repository<SubjectApiContext, Subject>, ISubjectRepository
    {
        public SubjectRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {
            _subjectProducts = unitOfWork.GetDbContext().Set<SubjectProductRelation>();
        }

        public DbSet<SubjectProductRelation> _subjectProducts;

        public async Task AddSubjectProductAsync(SubjectProductRelation entity)
        {
            await _subjectProducts.AddAsync(entity);
        }

        public async Task MutilAddSubjectProductAsync(List<SubjectProductRelation> entitys)
        {
            foreach (var item in entitys)
            {
                if (_subjectProducts.Any(c => c.ProductId == item.ProductId && c.SubjectId == item.SubjectId))
                    continue;
                await _subjectProducts.AddAsync(item);
            }
        }

        public async Task<List<SubjectProductRelation>> GetSubjectProductsAsync(Guid subjectId)
        {
            var subjectProductEntitys = await _subjectProducts.Where(c => c.SubjectId == subjectId).ToListAsync();
            return subjectProductEntitys;
        }
    }
}
