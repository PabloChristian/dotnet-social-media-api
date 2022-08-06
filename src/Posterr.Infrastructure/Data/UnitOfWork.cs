using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Posterr.Domain.Interface;
using Posterr.Infrastructure.Data.Context;
using Posterr.Shared.Kernel.Entity;

namespace Posterr.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosterrContext _posterrContext;

        public UnitOfWork(PosterrContext posterrContext) => _posterrContext = posterrContext;

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
            => await _posterrContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
