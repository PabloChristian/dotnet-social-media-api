﻿using Posterr.Domain.Interfaces.Repositories;
using Posterr.Shared.Kernel.Entity;
using Posterr.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly PosterrContext Db;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(PosterrContext PosterrContext)
        {
            Db = PosterrContext;
            DbSet = Db.Set<T>();
        }

        public void Add(T entity) => DbSet.Add(entity);
        public async Task AddAsync(T entity, CancellationToken cancellationToken) => await DbSet.AddAsync(entity, cancellationToken);
        public IQueryable<T> GetAll() => DbSet;
        public IQueryable<T> GetByExpression(System.Linq.Expressions.Expression<Func<T, bool>> predicate) => DbSet.Where(predicate);
        public T GetById(Guid id) => DbSet?.Find(id);
        public void Remove(T entity) => DbSet.Remove(entity);
        public void Update(T entity) => DbSet.Update(entity);
    }
}
