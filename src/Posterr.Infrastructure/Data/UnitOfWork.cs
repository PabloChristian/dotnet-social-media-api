using Posterr.Domain.Interface;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosterrContext _posterrContext;

        public UnitOfWork(PosterrContext posterrContext) => _posterrContext = posterrContext;

        public bool Commit() => _posterrContext.SaveChanges() > 0;

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
            => await _posterrContext.SaveChangesAsync(cancellationToken) > 0;


    }
}
