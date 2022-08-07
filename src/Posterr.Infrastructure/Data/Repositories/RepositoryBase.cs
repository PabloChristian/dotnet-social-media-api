using Posterr.Shared.Kernel.Entity;
using Posterr.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly PosterrContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(PosterrContext PosterrContext)
        {
            _context = PosterrContext;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public async Task AddAsync(T entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);
        public IQueryable<T> GetAll() => _dbSet;
        public IQueryable<T> GetByExpression(System.Linq.Expressions.Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
        public T GetById(Guid id) => _dbSet?.Find(id);
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void Update(T entity) => _dbSet.Update(entity);
    }
}
