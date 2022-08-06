namespace Posterr.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
