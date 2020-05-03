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
    public class PrefrenceAreaRepository : Repository<SubjectApiContext, PrefrenceArea>, IPrefrenceAreaRepository
    {
        public PrefrenceAreaRepository(IUnitOfWork<SubjectApiContext> unitOfWork) : base(unitOfWork)
        {
            _prefrenceAreaProducts = unitOfWork.GetDbContext().Set<PrefrenceAreaProductRelation>();
        }

        public DbSet<PrefrenceAreaProductRelation> _prefrenceAreaProducts;

        public async Task AddPrefrenceAreaProductAsync(PrefrenceAreaProductRelation entity)
        {
            await _prefrenceAreaProducts.AddAsync(entity);
        }

        public async Task MutilAddPrefrenceAreaProductAsync(List<PrefrenceAreaProductRelation> entitys)
        {
            foreach (var item in entitys)
            {
                if (_prefrenceAreaProducts.Any(c => c.ProductId == item.ProductId && c.PrefrenceAreaId == item.PrefrenceAreaId))
                    continue;
                await _prefrenceAreaProducts.AddAsync(item);
            }
        }

        public async Task<List<PrefrenceAreaProductRelation>> GetPrefrenceAreaProductsAsync(Guid prefrenceAreaId)
        {
            var prefrenceAreaProductEntitys = await _prefrenceAreaProducts.Where(c => c.PrefrenceAreaId == prefrenceAreaId).ToListAsync();
            return prefrenceAreaProductEntitys;
        }
    }
}
