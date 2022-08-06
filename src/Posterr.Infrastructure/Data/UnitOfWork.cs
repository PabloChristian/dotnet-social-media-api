using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosterrChatContext _posterrChatContext;

        public UnitOfWork(PosterrChatContext posterrChatContext) => _posterrChatContext = posterrChatContext;

        public bool Commit() => _posterrChatContext.SaveChanges() > 0;

        public async Task<bool> CommitAsync(CancellationToken cancellationToken) => 
            await _posterrChatContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
