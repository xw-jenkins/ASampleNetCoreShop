﻿using ASample.NetCore.Domain;
using ASample.NetCore.EntityFramwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.RelationalDb
{
    public class Repository<TDbContext, TEntity> : ASampleRepository<TEntity>, IRepository<TEntity>
        where TEntity : class,IAggregateRoot
        where TDbContext : DbContext
    {
        private DbSet<TEntity> _dbSet;
        public Repository(IUnitOfWork<TDbContext> unitOfWork)
        {
            _dbSet = unitOfWork.GetDbContext().Set<TEntity>();
        }
        public override void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public override void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public override IQueryable<TEntity> GetAll()
        {
            var result = _dbSet.AsQueryable().Where(c => !c.IsDeleted);
            return result;
        }

        public override TEntity Insert(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            return result.Entity;
        }

        public override Task MultipleInsert(List<TEntity> entity)
        {
             _dbSet.AddRange(entity);
            return Task.FromResult(0);
        }

        public override TEntity Update(TEntity entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity;
        }

        public override Task MultipleUpdate(List<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
            return Task.FromResult(0);
        }

        public override Task PhysicalDelete(TEntity entity)
        {
            var result = _dbSet.Remove(entity);
            return Task.FromResult(0);
        }
    }
}
