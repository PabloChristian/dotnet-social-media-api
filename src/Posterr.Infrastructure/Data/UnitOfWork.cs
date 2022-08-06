using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosterrContext _PosterrContext;

        public UnitOfWork(PosterrContext PosterrContext) => _PosterrContext = PosterrContext;

        public bool Commit() => _PosterrContext.SaveChanges() > 0;

        public async Task<bool> CommitAsync(CancellationToken cancellationToken) => 
            await _PosterrContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
